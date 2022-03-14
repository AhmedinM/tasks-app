using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Users;
using Core.Entities;

namespace BusinessLayer.Services.Accounts
{
    public interface IAccountService
    {
        Task<UserDto> RegisterUser(CreateUserDto createUserDto);
        Task<bool> CheckEmail(string email);
        Task<UserDto> Login(CreateUserDto createUserDto);
        Task<GetUserDto> UpdatePassword(UpdateUserDto updateUserDto);
        Task<bool> DeleteUser(UpdateUserDto updateUserDto);
    }
}