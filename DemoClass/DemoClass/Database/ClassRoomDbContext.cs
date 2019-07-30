using DemoClass.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoClass.Database
{
    public class ClassRoomDbContext : DbContext
    {
        public ClassRoomDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(c => new { c.Id });
        }
    }
}
