using Microsoft.EntityFrameworkCore;

namespace shop25.Data.Contex
{
    public class UserContex: DbContext
    {
        public UserContex(DbContextOptions<UserContex> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }

    }
}
