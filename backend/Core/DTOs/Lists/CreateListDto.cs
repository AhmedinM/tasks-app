using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Lists
{
    public class CreateListDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}