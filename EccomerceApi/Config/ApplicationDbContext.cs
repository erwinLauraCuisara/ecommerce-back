using EccomerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EccomerceApi.Config
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Product> Products { get; set; }

        //public string DbPath { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Cost = 200.0, Description = "Description", ImageRoute = "ee"},
                new Product { Id = 2, Name = "Product 2", Cost = 300.0, Description = "Description 2", ImageRoute = "ee" },
                new Product { Id = 3, Name = "Product 3", Cost = 400.0, Description = "Description 3", ImageRoute = "ee" },
                new Product { Id = 4, Name = "Product 4", Cost = 500.0, Description = "Description 4", ImageRoute = "ee" },
                new Product { Id = 5, Name = "Product 5", Cost = 600.0, Description = "Description 5", ImageRoute = "ee" }
                );
            base.OnModelCreating(modelBuilder);
        }


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   => optionsBuilder.UseSqlite($"Data Source={DbPath}");

    }
}
