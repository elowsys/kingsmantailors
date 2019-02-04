using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KingsmanTailors.API.Dtos;
using KingsmanTailors.API.Models;

namespace KingsmanTailors.API.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add<TEntity>(T entity) where TEntity : class;

        void Delete<TEntity>(T entity) where TEntity : class;

        Task<T> Get(object id);

        Task<T> Find(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> GetAll();

        Task<bool> SaveAll();
    }
}
