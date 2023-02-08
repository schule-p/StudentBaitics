using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseSerialColumns();
            base.OnModelCreating(builder);
            builder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                StudentName = "Виктор Корнеплод",
                Points = 1000
            }
            );

        }
    }
}
