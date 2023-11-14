using Microsoft.EntityFrameworkCore;
using shop25.Data.Model;

namespace shop25.Data.Contex
{
    public class OrderContex:DbContext
    {
        public OrderContex(DbContextOptions<OrderContex> options) : base(options)
        {

        }
        public DbSet<ORDER> order { get; set; }
    }
}
