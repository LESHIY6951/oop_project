using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Model;

namespace shop25.Controllers
{

    [ApiController]
    [Route("Forum")]
    public class ForumController:Controller
    {
        private readonly ForumContex _forum;
        public ForumController(ForumContex forum)
        {
            _forum = forum;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Forum forum)
        {
            _forum.Forum.Add(forum);
            await _forum.SaveChangesAsync();
            return Ok(forum);
        }
        [HttpGet]
        public async Task<IActionResult> Forum()
        {
            var forum = await _forum.Forum.ToListAsync();
            return Ok(forum);
        }
        [HttpPut]
        public async Task<IActionResult> Like (Forum forum)
        {
            forum.like = forum.like + 1;
            await _forum.SaveChangesAsync();
            return Ok(forum);
        }
        [HttpPatch]
        public async Task<IActionResult> DisLike(Forum forum)
        {
            forum.dislike = forum.dislike + 1;
            await _forum.SaveChangesAsync();
            return Ok(forum);
        }
    }
}
