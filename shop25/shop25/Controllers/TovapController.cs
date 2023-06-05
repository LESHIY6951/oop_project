using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Interfaces;
using shop25.Data.Model;

namespace shop25.Controllers
{
    [ApiController]
    [Route("Tovap")]
    public class TovapController: Controller
    {

            private readonly  TovapContex _tovap;
            public TovapController(TovapContex tovap)
            {
                _tovap = tovap;
            }
        [HttpGet]
        public async Task<IActionResult> Tovap()
        {
            var tovap = await _tovap.Tovap.ToListAsync();
            return Ok (tovap);
        }
    }
}
