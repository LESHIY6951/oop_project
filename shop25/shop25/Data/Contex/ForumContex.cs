using Microsoft.EntityFrameworkCore;
using shop25.Data.Model;

namespace shop25.Data.Contex
{
    public class ForumContex:DbContext
    {


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       modelBuilder.Entity<Forum>().HasNoKey();
       }
        public ForumContex(DbContextOptions<ForumContex> options) : base(options)
        {

        }
        public DbSet<Forum> Forum { get; set; }
    }
}
