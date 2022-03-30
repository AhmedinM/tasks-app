using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Tasks
{
    public class CreateTaskDto
    {
        [Required]
        public string? Text { get; set; }
        [Required]
        public int ListId { get; set; }
    }
}