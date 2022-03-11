using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<List>? Lists { get; set; }
        // public ICollection<Role>? Roles { get; set; }
    }
}