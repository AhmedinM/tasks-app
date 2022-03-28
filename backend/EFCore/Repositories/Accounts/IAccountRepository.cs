using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Users;
using Core.Entities;

namespace EFCore.Repositories.Accounts
{
    public interface IAccountRepository
    {
        Task<User?> GetUserByEmail(string email);
        Task<User> RegisterUser(User user, string password);
        // Task<GetUserDto> Login(CreateUserDto createUserDto);
        Task<User> UpdateUser(User user);
        System.Threading.Tasks.Task DeleteUser(User user);
    }
}