using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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