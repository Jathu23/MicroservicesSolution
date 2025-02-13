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
    }
}
