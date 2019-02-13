using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KingsmanTailors.API.Dtos;
using KingsmanTailors.API.Interfaces;
using KingsmanTailors.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KingsmanTailors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            this._repo = repo;
            this._config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // convert to lower case
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            //is it unique?
            if (await _repo.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists");
            }

            var newUser = new User
            {
                DisplayName = userForRegisterDto.DisplayName,
                Email = userForRegisterDto.Email,
                Gender = userForRegisterDto.Gender,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                UserId = new Guid(userForRegisterDto.Username).ToString(),
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(newUser, userForRegisterDto.Password);

            //now add to role if role supplied
            if (createdUser != null)
            {
                await _repo.AddToRole(createdUser, userForRegisterDto.RoleCode);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var fromDb = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
            if (fromDb == null)
            {
                return Unauthorized();
            }

            //write token into response and send back to user
            var result = getSecurityToken(fromDb);
            return Ok(new { token = result });
        }

        [HttpGet("refresh/{id}")]
        public async Task<IActionResult> RefreshUser(string id)
        {
            // make sure that the credentials match and only doing for self
            var editorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (editorId == 0)
            {
                return Unauthorized();
            }

            var editorUserId = User.FindFirst(ClaimTypes.PrimarySid).Value;
            if (string.IsNullOrEmpty(editorUserId))
            {
                return Unauthorized();
            }

            // make sure that this user is of admin role
            var editor = await _repo.GetUser(id);
            if (editor == null)
            {
                return BadRequest();
            }

            // make sure that the user is the same as in token
            if (editor.UserId == editorUserId)
            {
                var result = getSecurityToken(editor);
                return Ok(new { token = result });
            }

            return Unauthorized();
        }

        private string getSecurityToken(User fromDb)
        {
            //build a token that is returned to the user that can be used for authentication
            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, fromDb.Id.ToString()),
                new Claim(ClaimTypes.Name, fromDb.Username),
                new Claim(ClaimTypes.GivenName, fromDb.DisplayName),
                new Claim(ClaimTypes.Role, fromDb.RoleCode),
                new Claim(ClaimTypes.Webpage, fromDb.Url??""),
                new Claim(ClaimTypes.PrimarySid, fromDb.UserId)
            };

            //security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            //signing credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //security token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
