using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Users;
using Core.Entities;

namespace BusinessLayer.Services.Users
{
    public interface IAccountService
    {
        Task<User> RegisterUser(CreateUserDto createUserDto);
        Task<bool> CheckEmail(string email);
        Task<User> Login(CreateUserDto createUserDto);
    }
}