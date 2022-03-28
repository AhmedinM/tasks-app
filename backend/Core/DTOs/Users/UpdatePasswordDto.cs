using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs.Users
{
    public class UpdatePasswordDto : UpdateUserDto
    {
        [Required]
        public string? OldPassword { get; set; }
    }
}