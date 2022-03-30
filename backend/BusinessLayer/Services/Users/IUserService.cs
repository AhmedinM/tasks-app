using Core.DTOs.Users;

namespace BusinessLayer.Services.Users
{
    public interface IUserService
    {
        Task<List<GetUserDto>> GetUsers(int userId);
        Task<GetUserDto> GetUser(int userId);
        Task<GetUserDto> GetUserByEmail(string email);
    }
}