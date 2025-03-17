namespace YaradiciEduAz.Entities
{
    public class Slide
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        public string? Thumb { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
