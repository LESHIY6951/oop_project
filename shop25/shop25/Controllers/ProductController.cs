using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Model;
namespace shop25.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:Controller

    {
        private readonly ProductContex _product;
        public ProductController(ProductContex product)
        {
            _product = product;
        }
        [HttpGet]
        public async Task<IActionResult> Product()
        {
            var product = await _product.Products.ToListAsync();
            return Ok(product);
        }
        [HttpGet("{item_id}")]
        public async Task<IActionResult> Products(int item_id)
        {
            var result = await _product.Products.FirstOrDefaultAsync(x => x.item_id == item_id);
            return Ok(result);
    }
}
}
