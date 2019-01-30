using System;
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

        public async Task<User> Login(string username, string password)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }

            //now compare password and hash
            if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }


        public async Task<User> Register(User user, string password)
        {
            byte[] pwdHash;
            byte[] pwdSalt;

            CreatePassowordHash(password, out pwdHash, out pwdSalt);
            user.PasswordHash = pwdHash;
            user.PasswordSalt = pwdSalt;

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            return await DbContext.Users.AnyAsync(x => x.Username == username);
        }


        private void CreatePassowordHash(string password, out byte[] pwdHash, out byte[] pwdSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                pwdSalt = hmac.Key;
                pwdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
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
