using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace shop25
{
      [ApiController]
    [Route("User")]

    public class UserController : Controller
    {
        private readonly UserContex _user;
        public UserController (UserContex user)
        {
            _user = user;
        }
        [HttpGet]
        public async Task<IActionResult> UserGet ()
        {
            var users = await _user.User.ToListAsync();
            return Ok(users);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Id(int id)
        {
            var result = await _user.User.FindAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _user.User.Add(user);
            await _user.SaveChangesAsync();
            return Ok(user);
        }
    }

}
