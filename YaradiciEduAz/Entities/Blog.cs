using System.ComponentModel.DataAnnotations;

namespace YaradiciEduAz.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Thumbnail { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public Category? Category { get; set; }

    }
}
