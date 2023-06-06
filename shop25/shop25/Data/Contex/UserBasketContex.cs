using Microsoft.EntityFrameworkCore;
using shop25.Data.Model;

namespace shop25.Data.Contex
{
    public class UserBasketContex: DbContext
    {
        public UserBasketContex(DbContextOptions<UserBasketContex> options) : base(options)
        {

        }
        public DbSet<cart> cart { get; set; }
    }
}
