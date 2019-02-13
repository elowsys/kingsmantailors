using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using KingsmanTailors.API.Dtos;
using KingsmanTailors.API.Interfaces;
using KingsmanTailors.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingsmanTailors.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repo;

        private readonly IMapper _mapper;
        private readonly IRepository<UserRole> _userRole;
        private readonly IRepository<Role> _role;

        public UsersController(
            IRepository<User> repo,
            IRepository<UserRole> userRole,
            IRepository<Role> role,
            IMapper mapper)
        {
            _repo = repo;
            _userRole = userRole;
            _role = role;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.Get(id);
            var result = _mapper.Map<UserForDetailedDto>(user);
            // patch in rolecode
            var role = await _userRole.Find(x => x.UserId == user.UserId);
            if (role != null && result != null)
            {
                result.RoleCode = role.RoleId;
            }
            return Ok(result);
        }

        [HttpGet("uid/{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _repo.Find(x => x.UserId == userId);
            var result = _mapper.Map<UserForDetailedDto>(user);
            // patch in rolecode
            var role = await _userRole.Find(x => x.UserId == user.UserId);
            if (role != null && result != null)
            {
                result.RoleCode = role.RoleId;
            }
            return Ok(result);
        }

        [HttpGet("rid/{userId}")]
        public async Task<IActionResult> GetRoleByUserId(string userId)
        {
            var user = await _userRole.Find(x => x.UserId == userId);
            if (user != null)
            {
                var role = await _role.Find(x => x.RoleId == user.RoleId);
                return Ok(role);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetAll();
            var result = _mapper.Map<IEnumerable<UserForListDto>>(users);
            if (result != null)
            {
                // patch in rolecode
                var roles = await _userRole.GetAll();
                if (roles != null)
                {
                    foreach (var user in result)
                    {
                        var role = roles.FirstOrDefault(x => x.UserId == user.UserId);
                        if (role != null)
                        {
                            user.RoleCode = role.RoleId + "|" + role.Id;
                        }
                    }
                }
            }
            return Ok(result);
        }
        [HttpPost()]
        public async Task<IActionResult> CreateUser(UserForRegisterDto userForRegister)
        {
            // make sure that we have the user making the changes and that user is allowed to make changes
            // and the user can create users at their level and beneath
            var editorRoleId = await isValidEditor();
            if (editorRoleId == null)
            {
                return Unauthorized();
            }

            //map to supplied
            var toDbUser = new User();
            _mapper.Map(userForRegister, toDbUser);
            setSecurityStamp(ref toDbUser, userForRegister.Password);
            toDbUser.AccessFailedCount = 0;
            toDbUser.AccountConfirmed = false;
            toDbUser.LockedOutEnabled = false;
            toDbUser.LockedOutEnd = DateTime.Parse("01-01-1900T00:00:00");
            _repo.Add<User>(toDbUser);
            if (await _repo.SaveAll())
            {
                // add user to role
                var fromDb = await _repo.Find(x => x.Username == toDbUser.Username);
                if (fromDb == null)
                {
                    throw new Exception($"Failed to find user: {toDbUser.Username}");
                }

                var fromDbRole = await _role.Find(x => x.RoleId == userForRegister.RoleCode);
                if (fromDbRole != null)
                {
                    var toUserRole = new UserRole { RoleId = fromDbRole.RoleId, UserId = fromDb.UserId };
                    _userRole.Add<UserRole>(toUserRole);
                    if (!await _userRole.SaveAll())
                    {
                        return BadRequest("Failed to update create user in role");
                        // throw new Exception("Failed to update create user in role");
                    }
                }
                return NoContent();
            }
            return BadRequest("Failed to create user");
            // throw new Exception("Failed to create user");
        }

        [HttpPut("{uid}")]
        public async Task<IActionResult> UpdateUser(string uid, UserForEditDto userForEdit)
        {
            if (uid == "")
            {
                return Unauthorized();
            }

            //Is the editor's role id greater than the userForEdit role id? Disallow - editors can only edit roles at and beneath their role
            var editorRoleId = await isValidEditor();
            if (editorRoleId == null)
            {
                return Unauthorized();
            }

            var fromDb = await _repo.Find(x => x.UserId == uid);
            if (fromDb == null)
            {
                throw new Exception($"Failed to find user: {uid}");
            }
            var resetDate = fromDb.LockedOutEnd;

            // now get the role
            var fromDbRole = await _userRole.Find(x => x.UserId == fromDb.UserId);
            if (fromDbRole == null)
            {
                throw new Exception($"Failed to find data for user: {uid}");
            }

            var fromDbRoleId = await _role.Find(x => x.RoleId == fromDbRole.RoleId);
            if (fromDbRoleId == null)
            {
                throw new Exception("Missing data");
            }

            if (editorRoleId.Id > fromDbRoleId.Id)
            {
                return Unauthorized();
            }

            //map to supplied
            _mapper.Map(userForEdit, fromDb);

            // if account being unlocked then reset accessFailedCount to 0
            if (resetDate != fromDb.LockedOutEnd && fromDb.LockedOutEnd.Year == 1900)
            {
                fromDb.AccessFailedCount = 0;
            }

            var success = await _repo.SaveAll();

            // change the role also if not the same
            if (fromDbRole != null && userForEdit.RoleCode != fromDbRole.RoleId)
            {
                fromDbRole.RoleId = userForEdit.RoleCode;
                if (!await _userRole.SaveAll())
                {
                    return BadRequest($"Failed to update user role for user {uid} from '{userForEdit.RoleCode}' to '{fromDbRole.RoleId}'");
                    // throw new Exception($"Failed to update user role for user {uid} from '{userForEdit.RoleCode}' to '{fromDbRole.RoleId}'");
                }
                success = true;
            }

            if (!success)
            {
                return BadRequest($"Failed to complete update on user {uid}");
                // throw new Exception($"Failed to complete update on user {uid}");
            }
            return NoContent();
        }

        private User setSecurityStamp(ref User user, string password)
        {
            using (var hmac = new HMACSHA512())
            {
                user.SecurityStamp = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return user;
        }

        private async Task<Role> isValidEditor()
        {
            // make sure that we have the user making the changes and that user is allowed to make changes
            var editorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (editorId == 0)
            {
                return null;
            }

            // make sure that this user is of admin role
            var editor = await _repo.Get(editorId);
            if (editor == null)
            {
                return null;
            }

            // get the role
            var editorRole = await _userRole.Find(x => x.UserId == editor.UserId);
            if (editorRole == null)
            {
                return null;
            }

            // is the user roleId id greater than user being updated
            return await _role.Find(x => x.RoleId == editorRole.RoleId);
        }
    }
}
