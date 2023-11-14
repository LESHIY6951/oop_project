using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop25.Data.Contex;
using shop25.Data.Model;

namespace shop25.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ForumController:Controller
    {
        private readonly ForumContex _forum;
        public ForumController(ForumContex forum)
        {
            _forum = forum;
        }
        [HttpPost]
        public async Task<IActionResult> Create(forum forum)
        {
            _forum.forum.Add(forum);
            await _forum.SaveChangesAsync();
            return Ok(forum);
        }
        [HttpGet]
        public async Task<IActionResult> Forum()
        {
            var forum = await _forum.forum.ToListAsync();
            return Ok(forum);
        }
        [HttpPost("{forum_id}")]
        public async Task<IActionResult> Like (int forum_id)
        {
            var forum= await _forum.forum.FindAsync(forum_id);
           forum.likes = forum.likes + 1;
            await _forum.SaveChangesAsync();
            return Ok(forum);
        }
        [HttpPost("dislike/{forum_id}")]
        public async Task<IActionResult> DisLike(int forum_id)
        {
            var forum = await _forum.forum.FindAsync(forum_id);
            forum.dislikes = forum.dislikes + 1;
            await _forum.SaveChangesAsync();
            return Ok(forum);
        }
    }
}
