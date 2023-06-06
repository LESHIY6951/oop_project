using Microsoft.EntityFrameworkCore;
using shop25.Data.Model;

namespace shop25.Data.Contex
{
    public class TovapContex:DbContext
    {
        public TovapContex(DbContextOptions<TovapContex> options) : base(options)
        {

        }
        public DbSet<Tovap> Tovap { get; set; }
    }
}
