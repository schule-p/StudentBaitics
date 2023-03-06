using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Transactions> Transactions { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            //builder.Entity<Student>()
            //    .HasOne(b => b.Transactions)
            //    .WithOne(i => i.Student)
            //    .HasForeignKey<Transactions>(b => b.IdStudent);
            

            builder.UseSerialColumns();
            base.OnModelCreating(builder);
            builder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                StudentName = "Виктор Корнеплод",
                Points = 1000
            }
            );
            builder.Entity<Products>().HasData(new Products
            {
                
                Id = 1,
                ProductName = "Худи",
                ProductCount = 19
                
            }
            );
            builder.Entity<Transactions>().HasData(new Transactions
            {
                Id = 1,
                IdStudent = 1,
                Sum = 100,
                TypeOfTransaction = false
            }
           );

        }
    }
}
