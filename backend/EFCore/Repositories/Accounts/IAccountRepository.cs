using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Users;
using Core.Entities;

namespace EFCore.Repositories.Users
{
    public interface IAccountRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> RegisterUser(User user);
        Task<GetUserDto> Login(CreateUserDto createUserDto);
    }
}