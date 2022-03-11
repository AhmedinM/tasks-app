using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace EFCore.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}