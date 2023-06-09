using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Model;

namespace shop25.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Order_HistoriController: Controller
    {

            private readonly  order_historyContex _order;
            public Order_HistoriController(order_historyContex order)
            {
                _order = order;
            }
        [HttpGet("{user_id}")]
        public async Task<IActionResult> order_history(int user_id)
        {
            var order = await _order.history.Where(x=>x.user_id==user_id).ToListAsync(); 
            return Ok (order);
        }
        [HttpPost]
        public async Task<IActionResult> Dobav(history order)
        {
            _order.history.Add(order);
            await _order.SaveChangesAsync();
            return Ok(order);
        }
    }
}
