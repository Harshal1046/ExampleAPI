using ExampleAPI.Interfaces;
using ExampleAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Repositories
{
    public class ProductRepository : IRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get All Categories
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var resources = await _context.Categories.ToListAsync();

            return resources;
        }


        // Get All Products
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var resources = await _context.Products.Include(c => c.Category).OrderBy(o => o.CategoryId).ToListAsync();

            return resources;
        }


        // Add Category
        public void AddCategory(Category category)
        {
            var resources = _context.Categories.AddAsync(category);

            _context.SaveChangesAsync();
        }


        // Add Bulk Products
        public void BulkAdd(List<Product> products)
        {
            foreach (var product in products)
            {
                // To Check If Product Already Exist Or Not
                var existing = _context.Products.Where(x => x.CategoryId == product.CategoryId && x.ProductName == product.ProductName).FirstOrDefault();

                //
                if (existing != null)
                {
                    // Update
                    existing.ProductAmount = product.ProductAmount;
                }
                else
                {
                    // Add New
                    _context.Products.Add(product);
                }
            }

            // 
            _context.SaveChanges();
        }

    }
}
