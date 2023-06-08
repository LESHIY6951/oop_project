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

            private readonly  OrderContex _tovap;
            public Order_HistoriController(OrderContex tovap)
            {
                _tovap = tovap;
            }
        [HttpGet]
        public async Task<IActionResult> Tovap()
        {
            var tovap = await _tovap.order_history.ToListAsync();
            return Ok (tovap);
        }
    }
}
