using Asp_Dot_Net_Web_Api_Prac.Models;
using Asp_Dot_Net_Web_Api_Prac.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Dot_Net_Web_Api_Prac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        //Method to get all products
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        //Method to get a product by id
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            if (id == 0)
                return BadRequest("Id is required");

            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        //Method to create a new product
        [HttpPost]
        public ActionResult<Product> CreateNewProduct(Product product)
        {
            if (product == null)
                return BadRequest("Product is required");
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        //Method to Delete a product by id
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProductById(int id)
        {
            if (id == 0)
                return BadRequest("Id is required");
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound("Product not found");

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }

        //Method to Update a product by Id
        [HttpPut]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            bool productExists = _context.Products.Any(p => p.ProductId == product.ProductId);
            if (!productExists)
                return NotFound($"Product with {product.ProductId} not found");

            _context.Products.Update(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}
