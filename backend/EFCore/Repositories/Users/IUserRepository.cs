using Core.Entities;

namespace EFCore.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers(int userId);
        Task<User> GetUser(int userId);
        Task<User> GetUserByEmail(string email);
    }
}