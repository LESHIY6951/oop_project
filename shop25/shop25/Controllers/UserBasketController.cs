using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Model;

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
            List<Products> mass= new List<Products>();
             var userBasket = await _userBasket.cart.Where(x=>x.user_id==user_id).ToListAsync();
            for (int i = 0; i < userBasket.Count; i++)
            {
                var product = await _product.Products.FirstOrDefaultAsync(x => x.item_id == userBasket[i].item_id);
                if (product != null)
                {
                    mass.Add(product);
                }
            }
            return Ok(mass);
            }
          
        [HttpPost]
            public async Task<IActionResult> Create(cart userCart)
            {
               //var product = _product.Products.FirstOrDefaultAsync(x=>x.item_id== userCart.item_id);

                _userBasket.cart.Add(userCart);
                await _userBasket.SaveChangesAsync();
                return Ok(userCart);
            }
        [HttpDelete("{item_id}")]
            public async Task<IActionResult> Delete(int item_id,int user_id)
            {

                 var userCart = await _userBasket.cart.FirstOrDefaultAsync(x => x.item_id == item_id && x.user_id==user_id);
                _userBasket.cart.RemoveRange(userCart);
                await _userBasket.SaveChangesAsync();
                return Ok(userCart);
            }
       [HttpDelete("Clear/{user_id}")]
        public async Task<IActionResult> Clear(int user_id)
        {
            var userCart = await _userBasket.cart.Where(x => x.user_id == user_id).ToListAsync();
            _userBasket.cart.RemoveRange(userCart);
            await _userBasket.SaveChangesAsync();
            return Ok(userCart);
        }
    }

}
