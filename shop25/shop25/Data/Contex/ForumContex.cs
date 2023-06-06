using Microsoft.EntityFrameworkCore;
using shop25.Data.Model;

namespace shop25.Data.Contex
{
    public class ForumContex:DbContext
    {


       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       modelBuilder.Entity<forum>().HasNoKey();
       }
        public ForumContex(DbContextOptions<ForumContex> options) : base(options)
        {

        }
        public DbSet<forum> forum { get; set; }
    }
}
