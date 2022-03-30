using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Users
{
    public class DeleteUserDto
    {
        [Required]
        public int Id { get; set; }
    }
}