using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Database Models

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category
            modelBuilder.Entity<Category>()
                .Property(p => p.CategoryName)
                .HasMaxLength(30)
                .IsRequired();

            // Product
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductAmount)
                .IsRequired();


            // To Add Initial Data

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Category 1" },
                new Category { Id = 2, CategoryName = "Category 2" },
                new Category { Id = 3, CategoryName = "Category 3" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ProductName = "Product 101", ProductAmount = "10", CategoryId = 1 },
                new Product { Id = 2, ProductName = "Product 102", ProductAmount = "10", CategoryId = 1 },
                new Product { Id = 3, ProductName = "Product 201", ProductAmount = "10", CategoryId = 2 },
                new Product { Id = 4, ProductName = "Product 202", ProductAmount = "10", CategoryId = 2 },
                new Product { Id = 5, ProductName = "Product 301", ProductAmount = "10", CategoryId = 3 }
            );

        }

    }
}
