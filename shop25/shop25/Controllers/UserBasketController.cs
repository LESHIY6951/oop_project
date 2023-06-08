using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Model;

namespace shop25.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserBasketController:Controller
    {
            private readonly UserBasketContex _userBasket;
           private readonly ProductContex _product;
        public UserBasketController(UserBasketContex userBasket)
            {
                _userBasket = userBasket;
            }

            [HttpGet]
            public async Task<IActionResult> UserBasket()
            {
                var userBasket = await _userBasket.cart.ToListAsync();
                return Ok(userBasket);
            }

        [HttpPost]
            public async Task<IActionResult> Create(cart userCart)
            {
                _userBasket.cart.Add(userCart);
                await _userBasket.SaveChangesAsync();
                return Ok(userCart);
            }

            [HttpDelete("{item_id}")]
            public async Task<IActionResult> Delete(int item_id)
            {
                var userCart = await _userBasket.cart.FirstOrDefaultAsync(x => x.item_id == item_id);
            if (userCart != null)
            {
                _userBasket.cart.RemoveRange(userCart);
                await _userBasket.SaveChangesAsync();

                return Ok(userCart);
            }
            else return (null);
            }
        }
}
