using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace BusinessLayer.Services.Users
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}