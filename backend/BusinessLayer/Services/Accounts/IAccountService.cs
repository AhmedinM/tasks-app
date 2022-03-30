using Core.DTOs.Users;

namespace BusinessLayer.Services.Accounts
{
    public interface IAccountService
    {
        Task<UserDto> RegisterUser(CreateUserDto createUserDto);
        Task<UserDto> RegisterAdmin(CreateUserDto createUserDto);
        Task<bool> CheckEmail(string email);
        Task<UserDto> Login(CreateUserDto createUserDto);
        Task<GetUserDto> UpdatePassword(UpdatePasswordDto updatePasswordDto);
        Task<bool> DeleteUser(UpdateUserDto updateUserDto);
        Task<bool> AdminDeleteUser(DeleteUserDto deleteUserDto);
    }
}