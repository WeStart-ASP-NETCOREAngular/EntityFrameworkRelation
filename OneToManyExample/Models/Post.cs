

namespace OneToManyExample.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Body { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
