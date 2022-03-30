namespace Core.DTOs.Lists
{
    public class GetListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
    }
}