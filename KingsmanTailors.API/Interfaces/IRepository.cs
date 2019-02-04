using System.Collections.Generic;
using System.Threading.Tasks;
using KingsmanTailors.API.Dtos;
using KingsmanTailors.API.Models;

namespace KingsmanTailors.API.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();


        Task<T> Get<T>(object id) where T : class;

        Task<IEnumerable<T>> GetAll<T>() where T : class;

        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(object id);


    }
}
