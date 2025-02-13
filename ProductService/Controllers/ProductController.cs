using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ProductService.Data;
    using ProductService.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            //return Ok(await _context.Products.ToListAsync());
            return Ok("message from GetProducts");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(int number)
        {
            //_context.Products.Add(product);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);

            return Ok("message from GetProducts post"+ number);
        }
    }

}
