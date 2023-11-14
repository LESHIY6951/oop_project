using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using shop25.Data.Contex;
using shop25.Data.Model;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;

namespace shop25.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserBasketController : Controller
    {
        private readonly UserBasketContex _userBasket;
        private readonly ProductContex _product;
        public UserBasketController(UserBasketContex userBasket, ProductContex product)
        {
            _userBasket = userBasket;
            _product = product;
        }

        [HttpGet("{user_id}")]
        public async Task<IActionResult> UserBasket(int user_id)
        { 
            List<Basket> mass= new List<Basket>();
            var userBasket = await _userBasket.cart.Where(x=>x.user_id==user_id).ToListAsync();
            for (int i = 0; i < userBasket.Count; i++)
            {
                var product = await _product.Products.FirstOrDefaultAsync(x => x.item_id == userBasket[i].item_id);
                if (product != null)
                {
                    Basket basket = new Basket();
                    basket.item_id =product.item_id;   
                    basket.item_cost = product.item_cost;
                    basket.item_description = product.item_description;
                    basket.item_name = product.item_name;
                    basket.item_img = product.item_img;
                    basket.col = userBasket[i].col;
                    mass.Add(basket);
                }
            }
            return Ok(mass);
            }
          
        [HttpPost("{user_id},{item_id}")]
            public async Task<IActionResult> Create(int user_id, int item_id)
        {
            var userCart = await _userBasket.cart.FirstOrDefaultAsync(x => x.item_id == item_id && x.user_id == user_id);
            if (userCart == null)
            {
                var userBasket = new cart();
                userBasket.user_id = user_id;
                userBasket.item_id = item_id;
                userBasket.col = 1;
                _userBasket.cart.Add(userBasket);
            }
            else
              userCart.col++;
                await _userBasket.SaveChangesAsync();
                return Ok("Dobavleno");
            }
        [HttpDelete("{item_id},{user_id}")]
            public async Task<IActionResult> Delete(int item_id,int user_id)
            {

                 var userCart = await _userBasket.cart.FirstOrDefaultAsync(x => x.item_id == item_id && x.user_id==user_id);
            if (userCart.col == 1)
            {
                _userBasket.cart.RemoveRange(userCart);
            }
            else
                userCart.col--;
                await _userBasket.SaveChangesAsync();
                return Ok("Ydaleno");
            }
       [HttpDelete("Clear/{user_id}")]
        public async Task<IActionResult> Clear(int user_id)
        {
            var userCart = await _userBasket.cart.Where(x => x.user_id == user_id).ToListAsync();
            _userBasket.cart.RemoveRange(userCart);
            await _userBasket.SaveChangesAsync();
            return Ok("Clear");
        }
    }

}
