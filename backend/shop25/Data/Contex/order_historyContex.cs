using Microsoft.EntityFrameworkCore;
using shop25.Data.Model;

namespace shop25.Data.Contex
{
    public class order_historyContex:DbContext
    {
        public order_historyContex(DbContextOptions<order_historyContex> options) : base(options)
        {

        }
        public DbSet<history> history { get; set; }
    }
}
