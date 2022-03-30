namespace Core.DTOs.Users
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}