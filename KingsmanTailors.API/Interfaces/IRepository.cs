using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KingsmanTailors.API.Dtos;
using KingsmanTailors.API.Models;

namespace KingsmanTailors.API.Interfaces
{
    // public interface IRepository
    // {
    // }

    public interface IRepository<T> where T : class
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<T> Get(object id);

        Task<T> Find(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> GetAll();

        Task<bool> SaveAll();
    }
}
