using System;
using System.Linq;
using System.Threading.Tasks;
using KingsmanTailors.API.Interfaces;
using KingsmanTailors.API.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace KingsmanTailors.API.Data
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        public AuthRepository(DataContext context) : base(context)
        {
        }

        public async Task AddToRole(User user, string roleCode)
        {
            if (await DbContext.UserRoles.AnyAsync(x => x.UserId == user.UserId))
            {
                return;
            }

            // Add to role then
            var userRole = new UserRole
            {
                RoleId = roleCode,
                UserId = user.UserId
            };
            DbContext.UserRoles.Add(userRole);
            await DbContext.SaveChangesAsync();
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await DbContext.Users
                .FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }

            //now compare password and hash
            if (!verifyPassword(password, user.PasswordHash, user.SecurityStamp))
            {
                return null;
            }

            user.RoleCode = await getUserRole(user.UserId);
            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] pwdHash;
            byte[] pwdSalt;

            createPasswordHash(password, out pwdHash, out pwdSalt);
            user.PasswordHash = pwdHash;
            user.SecurityStamp = pwdSalt;

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            user.RoleCode = await getUserRole(user.UserId);
            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            return await DbContext.Users.AnyAsync(x => x.Username == username);
        }

        private void createPasswordHash(string password, out byte[] pwdHash, out byte[] pwdSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                pwdSalt = hmac.Key;
                pwdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private async Task<string> getUserRole(string userId)
        {
            // Get the role of this user before returning
            var userRole = await (from r in DbContext.Roles
                                  join ur in DbContext.UserRoles on r.RoleId equals ur.RoleId
                                  where ur.UserId == userId
                                  select r).FirstOrDefaultAsync();

            if (userRole != null)
            {
                // Found user
                return userRole.RoleId + "|" + userRole.RoleAbbrev;
            }
            return "";
        }

        private bool verifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
