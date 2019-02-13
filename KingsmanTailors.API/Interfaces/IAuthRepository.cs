using System.Threading.Tasks;
using KingsmanTailors.API.Models;

namespace KingsmanTailors.API.Interfaces
{
    public interface IAuthRepository
    {
        Task AddToRole(User createdUser, string roleCode);

        Task<User> GetUser(string id);

        Task<User> Login(string username, string password);

        Task<User> Register(User user, string password);

        Task<bool> UserExists(string username);
    }
}
