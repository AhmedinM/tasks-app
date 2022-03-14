using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Users;

namespace BusinessLayer.Services.Users
{
    public interface IUserService
    {
        Task<List<GetUserDto>> GetUsers();
        Task<GetUserDto> GetUser(int userId);
    }
}