namespace YaradiciEduAz.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Thumbnail { get; set; }
        public string? Link { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
