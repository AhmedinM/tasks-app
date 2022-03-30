using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Users
{
    public class CreateUserDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}