using System.Collections.Generic;
using System.Threading.Tasks;
using KingsmanTailors.API.Interfaces;
using System.Linq;
using KingsmanTailors.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using KingsmanTailors.API.Dtos;
using System.Linq.Expressions;

namespace KingsmanTailors.API.Data
{
    // public class Repository : BaseRepository, IRepository
    // {
    //     public Repository(DataContext context) : base(context)
    //     {
    //     }


    //     // public async Task<T> Get<T>(object id) where T : class
    //     // {
    //     //     return await DbContext.FindAsync<T>(id);
    //     // }

    //     // public async Task<IEnumerable<T>> GetAll<T>() where T : class
    //     // {
    //     //     IQueryable<T> query = DbContext.Set<T>();
    //     //     return await query.ToListAsync();
    //     // }

    //     // public async Task<IEnumerable<Role>> GetRoles()
    //     // {
    //     //     return await DbContext.Roles.ToListAsync();
    //     // }

    //     // public async Task<IEnumerable<User>> GetUsers()
    //     // {
    //     //     return await DbContext.Users.ToListAsync();
    //     // }

    //     // public async Task<Role> GetRole(object id)
    //     // {
    //     //     var byId = id.GetType().Name.Equals("String", StringComparison.CurrentCultureIgnoreCase);
    //     //     return byId ?
    //     //         await DbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == (string)id) :
    //     //         await DbContext.Roles.FirstOrDefaultAsync(x => x.Id == (int)id);
    //     // }

    //     // public async Task<User> GetUser(object id)
    //     // {
    //     //     var byId = id.GetType().Name.Equals("String", StringComparison.CurrentCultureIgnoreCase);
    //     //     return byId ?
    //     //         await DbContext.Users.FirstOrDefaultAsync(x => x.UserId == (string)id) :
    //     //         await DbContext.Users.FirstOrDefaultAsync(x => x.Id == (int)id);
    //     // }



    //     private bool resolveAction(dynamic x)
    //     {
    //         return x.Id != null;
    //     }
    // }

    public class Repository<T> : BaseRepository, IRepository<T> where T : class
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

        public async Task<T> Find(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbContext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> Get(object id)
        {
            return await DbContext.FindAsync<T>(id);
        }

        public async new Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = DbContext.Set<T>();
            return await query.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await DbContext.SaveChangesAsync() > 0;
        }
    }
}
