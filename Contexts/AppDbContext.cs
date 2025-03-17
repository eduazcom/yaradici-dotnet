using Microsoft.EntityFrameworkCore;
using YaradiciEduAz.Entities;

namespace YaradiciEduAz.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Category> Categories { get; set; }
        DbSet<Blog> Blogs { get; set; }
        DbSet<Setting> Settings { get; set; }
        DbSet<Slide> Slides { get; set; }
        DbSet<Teacher> Teachers { get; set; }

    }
}
