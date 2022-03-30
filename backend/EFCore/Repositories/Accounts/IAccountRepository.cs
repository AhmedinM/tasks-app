using Core.Entities;

namespace EFCore.Repositories.Accounts
{
    public interface IAccountRepository
    {
        Task<User?> GetUserByEmail(string email);
        Task<User> RegisterUser(User user, string password);
        Task<User> UpdateUser(User user);
        System.Threading.Tasks.Task DeleteUser(User user);
    }
}