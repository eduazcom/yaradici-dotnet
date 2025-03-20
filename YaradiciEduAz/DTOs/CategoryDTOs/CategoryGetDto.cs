using YaradiciEduAz.Entities;

namespace YaradiciEduAz.DTOs.CategoryDTOs
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime? Updated_At { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
    }
}
