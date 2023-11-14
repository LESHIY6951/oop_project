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
        private readonly UserBasketContex _userBasket;
        public OrderControllers(OrderContex order, UserBasketContex userBasket)
        {
            _order = order;
            _userBasket = userBasket;
        }
       [HttpGet]
        public async Task<IActionResult> Order()
        {
           var order = await _order.order.ToListAsync();
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> Dobav(ORDER order)
        {
            var order1 = await _userBasket.cart.Where(x => x.user_id == order.user_id).ToListAsync();
            for (int i = 0; i < order1.Count; i++)
            {
                ORDER one = new ORDER();
                one.user_id = order.user_id;
                one.item_id = order1[i].item_id;
                one.total_cost = order1[i].col;
                one.CVV = order.CVV;
                one.card_name = order.card_name;
                one.card_num = order.card_num;
                one.data = DateTime.Now;
                _order.order.Add(one);
            }
            await _order.SaveChangesAsync();
            return Ok("Ok");
        }
    }
}
