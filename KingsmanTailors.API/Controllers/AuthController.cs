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
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(newUser, userForRegisterDto.Password);
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

            //build a token that is returned to the user that can be used for authentication
            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, fromDb.Id.ToString()),
                new Claim(ClaimTypes.Name, fromDb.Username)
            };

            //security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            //signing credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //security token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //write token into response and send back to user
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}
