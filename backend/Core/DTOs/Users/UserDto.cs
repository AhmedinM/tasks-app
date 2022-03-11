using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}