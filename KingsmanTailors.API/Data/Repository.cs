using System.Collections.Generic;
using System.Threading.Tasks;
using KingsmanTailors.API.Interfaces;
using System.Linq;
using KingsmanTailors.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using KingsmanTailors.API.Dtos;

namespace KingsmanTailors.API.Data
{
    public class Repository : BaseRepository, IRepository
    {
        public Repository(DataContext context) : base(context)
        {
        }

        public void Add<T>(T entity) where T : class
        {
            DbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            DbContext.Remove(entity);
        }

        public async Task<T> Get<T>(object id) where T : class
        {
            return await DbContext.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await DbContext.FindAsync<T>(null) as IEnumerable<T>;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await DbContext.Users.ToListAsync();
        }

        public async Task<User> GetUser(object id)
        {
            var byUserId = id.GetType().Name.Equals("String", StringComparison.CurrentCultureIgnoreCase);
            return byUserId ?
                await DbContext.Users.FirstOrDefaultAsync(x => x.UserId == (string)id) :
                await DbContext.Users.FirstOrDefaultAsync(x => x.Id == (int)id);
        }

        // public async Task<UserForDetailedDto> GetDetailedUser(object id)
        // {
        //     var byUserId = id.GetType().Name.Equals("String", StringComparison.CurrentCultureIgnoreCase);
        //     var user = byUserId ?
        //     await DbContext.Users.FirstOrDefaultAsync(x => x.UserId == (string)id) :
        //     await DbContext.Users.FirstOrDefaultAsync(x => x.Id == (int)id);
        //     if (user != null)
        //     {
        //         return new UserForDetailedDto
        //         {
        //             AccessFailedCount = user.AccessFailedCount,
        //             AccountConfirmed = user.AccountConfirmed,
        //             DisplayName = user.DisplayName,
        //             Email = user.Email,
        //             Gender = user.Gender,
        //             Id = user.Id,
        //             LockedOutEnabled = user.LockedOutEnabled,
        //             LockedOutEnd = user.LockedOutEnd,
        //             PhoneNumber = user.PhoneNumber,
        //             UserId = user.UserId,
        //             Username = user.Username
        //         };
        //     }
        //     return default(UserForDetailedDto);
        // }

        // public async Task<List<UserForListDto>> GetUsersForList()
        // {
        //     var users = await DbContext.Users.ToListAsync();
        //     if (users.Any())
        //     {
        //         var data = new List<UserForListDto>();
        //         users.ForEach(x => data.Add(new UserForListDto
        //         {
        //             DisplayName = x.DisplayName,
        //             Email = x.Email,
        //             Gender = x.Gender,
        //             Id = x.Id,
        //             PhoneNumber = x.PhoneNumber,
        //             UserId = x.UserId,
        //             Username = x.Username
        //         }));
        //         return data;
        //     }
        //     return default(List<UserForListDto>);
        // }

        public async Task<bool> SaveAll()
        {
            return await DbContext.SaveChangesAsync() > 0;
        }

        private bool resolveAction(dynamic x)
        {
            return x.Id != null;
        }
    }
}
