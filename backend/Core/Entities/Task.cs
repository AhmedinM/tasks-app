using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public bool Finished { get; set; }
        public DateTime CreatedAt { get; set; }
        public List? List { get; set; }
        public int ListId { get; set; }
    }
}