using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Model;

namespace shop25.Controllers
{
    [ApiController]
    [Route("Basket")]
    public class UserBasketController:Controller
    {
            private readonly UserBasketContex _userBasket;
            public UserBasketController(UserBasketContex userBasket)
            {
                _userBasket = userBasket;
            }

            [HttpGet]
            public async Task<IActionResult> UserBasket()
            {
                var userBasket = await _userBasket.Basket.ToListAsync();
                return Ok(userBasket);
            }

        [HttpPost]
            public async Task<IActionResult> Create(UserBasket userCart)
            {
                _userBasket.Basket.Add(userCart);
                await _userBasket.SaveChangesAsync();
                return Ok(userCart);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteFavorites(int id)
            {
                var userCart = await _userBasket.Basket.FindAsync(id);
                _userBasket.Basket.RemoveRange(userCart);
                await _userBasket.SaveChangesAsync();

                return Ok(userCart);
            }
        }
}
