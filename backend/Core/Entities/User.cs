using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser<int>
    {
        public DateTime CreatedAt { get; set; }

        public ICollection<List>? Lists { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}