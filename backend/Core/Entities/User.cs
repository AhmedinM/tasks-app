using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser<int>
    {
        // public int Id { get; set; }
        // public string Email { get; set; }
        // public byte[] PasswordHash { get; set; }
        // public byte[] PasswordSalt { get; set; }
        // public string? Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<List>? Lists { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}