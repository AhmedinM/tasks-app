namespace Core.DTOs.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public string? Token { get; set; }
    }
}