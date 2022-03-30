using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Lists
{
    public class UpdateListDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}