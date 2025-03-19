using Microsoft.EntityFrameworkCore;
using YaradiciEduAz.Entities;

namespace YaradiciEduAz.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}
