using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> Getorders()
        {
            //return Ok(await _context.Products.ToListAsync());
            return Ok("message from order services ");
        }

        [HttpGet("{productId}")]
        public IActionResult GetOrdersByProductId(int productId)
        {
            var orders = new List<object>
    {
        new { OrderId = 101, ProductId = productId, Quantity = 2 },
        new { OrderId = 102, ProductId = productId, Quantity = 1 }
    };

            return Ok(orders);
        }

    }
}
