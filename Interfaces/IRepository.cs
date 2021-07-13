using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();

        Task<IEnumerable<Product>> GetAllProducts();

        void AddCategory(Category category);

        void BulkAdd(List<Product> products);
    }
}
