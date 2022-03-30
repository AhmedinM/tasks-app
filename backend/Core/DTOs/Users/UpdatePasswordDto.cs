using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Users
{
    public class UpdatePasswordDto : UpdateUserDto
    {
        [Required]
        public string? OldPassword { get; set; }
    }
}