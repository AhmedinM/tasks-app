using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Tasks
{
    public class UpdateTaskDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Text { get; set; }
    }
}