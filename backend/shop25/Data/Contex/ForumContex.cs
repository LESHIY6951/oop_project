using Microsoft.EntityFrameworkCore;
using shop25.Data.Model;

namespace shop25.Data.Contex
{
    public class ForumContex:DbContext
    {

        public ForumContex(DbContextOptions<ForumContex> options) : base(options)
        {

        }
        public DbSet<forum> forum { get; set; }
    }
}
