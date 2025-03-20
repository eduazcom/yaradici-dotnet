namespace YaradiciEduAz.Entities;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Created_At { get; set; } 
    public DateTime? Updated_At { get; set; }
    public ICollection<Blog>? Blogs { get; set; }

    public Category()
    {
        Created_At = DateTime.UtcNow;
    }
}
