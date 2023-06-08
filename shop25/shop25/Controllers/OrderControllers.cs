using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Model;

namespace shop25.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderControllers:Controller
    {
        private readonly OrderContex _order;
        public OrderControllers(OrderContex order)
        {
            _order = order;
        }
       [HttpGet]
        public async Task<IActionResult> Order()
        {
           var order = await _order.order.ToListAsync();
            return Ok(order);
        }
    }
}
