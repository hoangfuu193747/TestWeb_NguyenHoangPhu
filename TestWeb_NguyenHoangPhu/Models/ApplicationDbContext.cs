using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb_NguyenHoangPhu.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "ASP.NET Core", Author = "Microsoft", Price = 10.99M, Quantity = 100 },
                new Book { Id = 2, Title = "Entity Framework Core", Author = "EF Team", Price = 12.99M, Quantity = 50 },
                new Book { Id = 3, Title = "C# Fundamentals", Author = "Mark J. Price", Price = 15.49M, Quantity = 80 },
                new Book { Id = 4, Title = "Sleep", Author = "Sheep", Price = 10.29M, Quantity = 65 }
            );
        }
    }
}
