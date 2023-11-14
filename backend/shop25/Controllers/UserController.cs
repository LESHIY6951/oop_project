using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Model;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace shop25
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        private readonly UserContex _user;
        public UserController(UserContex user)
        {
            _user = user;
        }
        [HttpGet]
        public async Task<IActionResult> UserGet()
        {
            var users = await _user.User.ToListAsync();
           // var users = await _user.User.FirstOrDefaultAsync(x => x.login == user.login && x.password == user.password);
           //if (users == null)
           //return null;
           // else
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
            var users = await _user.User.FirstOrDefaultAsync(x => x.login == user.login);
            if (users == null)
            {
                if (user.cert_id == null)
                {
                    _user.User.Add(user);
                    await _user.SaveChangesAsync();
                    return Ok(user);
                }
                else
                {
                    users = await _user.User.FirstOrDefaultAsync(x => x.cert_id == user.cert_id);
                    if (users == null)
                    {

                        _user.User.Add(user);
                        await _user.SaveChangesAsync();
                        return Ok(user);
                    }
                    else
                        return Ok("sert zan");
                }
            }
            else
                return Ok("login zan");
        }
        [HttpPost("Cha")]
        public async Task<IActionResult> Сhanges(UserChanges user)
        {
            var users = await _user.User.FirstOrDefaultAsync(x => x.id == user.id);
                       users.cert_id=user.cert_id;
                      if(user.password!= null)
                      users.password=user.password;
                   users.name = user.name;
                   users.email=user.email;
                   users.number = user.number;
                   users.address = user.address;
                    await _user.SaveChangesAsync();
                    return Ok(users);
        }
    }
}
