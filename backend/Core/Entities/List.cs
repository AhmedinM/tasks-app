namespace Core.Entities
{
    public class List
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
        public int UserId { get; set; }
        public ICollection<Task>? Tasks { get; set; }
    }
}