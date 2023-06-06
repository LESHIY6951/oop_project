using Microsoft.EntityFrameworkCore;
using shop25.Data.Model;

namespace shop25.Data.Contex
{
    public class ProductContex : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasNoKey();
        }
        public ProductContex(DbContextOptions<ProductContex> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
    }
}
