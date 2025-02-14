using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    using System.Net.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ProductService.Data;
    using ProductService.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly HttpClient _httpClient;

        public ProductController(ProductDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            _context.Products.Add(product);
            var result = await _context.SaveChangesAsync();

            if (result == 1)
            {
                return Ok(product);
            }
            return Ok("error");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }

}
