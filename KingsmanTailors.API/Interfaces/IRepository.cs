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

        Task<bool> Any(Expression<Func<T, bool>> filter);

        void Delete<TEntity>(T entity) where TEntity : class;

        Task<T> Find(Expression<Func<T, bool>> filter);

        Task<T> Find<TInc>(Expression<Func<T, bool>> filter, Expression<Func<T, TInc>> include);

        Task<T> Get(object id);

        Task<IEnumerable<T>> GetAll();

        Task<bool> SaveAll();

        Task<IEnumerable<T>> ToList(Expression<Func<T, bool>> filter);
    }
}
