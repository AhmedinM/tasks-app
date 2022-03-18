using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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