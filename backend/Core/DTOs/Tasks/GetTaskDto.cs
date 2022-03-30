namespace Core.DTOs.Tasks
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public bool Finished { get; set; } = false;
        public int ListId { get; set; }
    }
}