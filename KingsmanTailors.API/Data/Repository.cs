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
    public class Repository<T> : BaseRepository, IRepository<T> where T : class
    {
        public Repository(DataContext context) : base(context)
        {
        }

        public void Add<TEntity>(T entity) where TEntity : class
        {
            DbContext.Add(entity);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbContext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.AnyAsync();
        }

        public void Delete<TEntity>(T entity) where TEntity : class
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

        public async Task<T> Find<TInc>(Expression<Func<T, bool>> filter, Expression<Func<T, TInc>> include)
        {
            IQueryable<T> query = DbContext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> Get(object id)
        {
            return await DbContext.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = DbContext.Set<T>();
            return await query.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await DbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> ToList(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbContext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync<T>();
        }
    }
}
