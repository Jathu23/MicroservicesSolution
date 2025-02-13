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
            //return Ok(await _context.Products.ToListAsync());
            return Ok("message from GetProducts");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] int number)
        {
            //_context.Products.Add(product);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);

            return Ok("message from GetProducts post" + number);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductWithOrders(int id)
        {
            var product = new { Id = id, Name = "Sample Product" };

            // 👇 Call OrderService API
            var ordersResponse = await _httpClient.GetAsync($"https://localhost:7180/api/Order/{id}");
            if (!ordersResponse.IsSuccessStatusCode)
            {
                return BadRequest("Failed to fetch orders");
            }

            var orders = await ordersResponse.Content.ReadAsStringAsync();

            return Ok(new { Product = product, Orders = orders });
        }
    }

}
