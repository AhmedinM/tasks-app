using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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