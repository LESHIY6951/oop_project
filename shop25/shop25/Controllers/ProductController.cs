using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;

namespace shop25.Controllers
{
    [ApiController]
    [Route("Product")]
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
            //var product = await _product.Product.Where(c=> c.cost <=100).ToListAsync();
            var product = await _product.Product.ToListAsync();
            return Ok(product);
        }
    }
}
