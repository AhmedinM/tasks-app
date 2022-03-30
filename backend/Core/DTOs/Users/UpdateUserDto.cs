using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Users
{
    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}