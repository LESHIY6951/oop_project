using Microsoft.EntityFrameworkCore;

namespace shop25.Data.Contex
{
    public class UserContex: DbContext
    {
      //  protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
          //  modelBuilder.Entity<User>().HasNoKey();
        //}
        public UserContex(DbContextOptions<UserContex> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }

    }
}
