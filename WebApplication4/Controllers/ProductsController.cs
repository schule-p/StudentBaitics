using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using System.Collections;
using System.Data.Entity;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("/api/Product")]
    public class ProductsController : Controller
    {
        
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)

        {
            this._context = context;
        }

        //Генерация уникального Id
        private int NextUniId => _context.Products.Count() == 0 ? 1 : _context.Products.Max(p => p.Id) + 1;

        [HttpGet("GetProducts")]
        public IActionResult GetStudents()
        {
            var x = _context.Products.ToList();
            var y = _context.Products;

            return Ok(x);
        }



        [HttpGet("{Id}")]
        public IActionResult GetProducts(int Id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == Id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(Models.Products productRequest)
        {
            var product = new Models.Products()
            {
                //Id = Guid.NewGuid(),
                Id = NextUniId,
                ProductName = productRequest.ProductName,
                Price = productRequest.Price,
                ProductCount = productRequest.ProductCount

            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            if (product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProduct(int Id, Models.Products productsRequest)
        {
            var product = await _context.Products.FindAsync(Id);

            if (product != null)
            {

                product.ProductName = productsRequest.ProductName;
                product.Price = productsRequest.Price;
                product.ProductCount = productsRequest.ProductCount;

                await _context.SaveChangesAsync();

                return Ok(product);
            }
            return NotFound();
        }



    }
}
