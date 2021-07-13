using ExampleAPI.Interfaces;
using ExampleAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }


        // Get All Categories
        [Route("~/api/Categories/GetAllCategories")]
        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            try
            {
                var result = await _repository.GetAllCategories();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        // Get All Products
        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            try
            {
                var result = await _repository.GetAllProducts();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        // Add Category
        [Route("~/api/Categories/AddCategory")]
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            try
            {
                if (category == null)
                    return BadRequest();

                _repository.AddCategory(category);

                return Ok("Category Added Successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error While Adding Data");
            }
        }


        // Add Bulk Products
        [Route("AddBulkProducts")]
        [HttpPost]
        public ActionResult AddBulkProducts(List<Product> product)
        {
            try
            {
                if (product == null)
                    return BadRequest();

                _repository.BulkAdd(product);

                return Ok("Products Added Successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error While Adding Data");
            }
        }
    }
}
