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
        private readonly ProductContex _product;
        private readonly UserBasketContex _userBasket;
        public Order_HistoriController(order_historyContex order, ProductContex product, UserBasketContex userBasket)
            {
                _order = order;
            _product = product;
            _userBasket = userBasket;
        }
        [HttpGet("{user_id}")]
        public async Task<IActionResult> order_history(int user_id)
        {
            List<order_history2> mass = new List<order_history2>();
            var order = await _order.history.Where(x=>x.user_id==user_id).ToListAsync();
                 for (int i = 0; i < order.Count; i++)
                {
                    var product = await _product.Products.FirstOrDefaultAsync(y => y.item_id == order[i].item_id);
                    order_history2 order2 = new order_history2();
                    order2.item_id = product.item_id;
                    order2.item_cost = product.item_cost;
                    order2.col = order[i].total_cost; // количество товара
                    order2.item_name = product.item_name;
                    order2.item_img = product.item_img;
                    order2.item_description = product.item_description;
                    order2.date = order[i].date;
                     mass.Add(order2);
            }
            return Ok (mass);
        }
        [HttpPost("{user_id}")]
        public async Task<IActionResult> Dobav(int user_id)
        {
            var order = await _userBasket.cart.Where(x=>x.user_id== user_id).ToListAsync();
            for(int i = 0; i < order.Count;i++)
            {
                history one = new history();
                one.user_id= user_id;
                one.item_id = order[i].item_id;
                one.total_cost = order[i].col;
                one.date= DateTime.Now;
                _order.history.Add(one);
            }
            _userBasket.cart.RemoveRange(order);
            await _order.SaveChangesAsync();
            await _userBasket.SaveChangesAsync();
            return Ok("Ok");
        }
    }
}
