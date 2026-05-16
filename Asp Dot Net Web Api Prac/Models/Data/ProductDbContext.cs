using Microsoft.EntityFrameworkCore;

namespace Asp_Dot_Net_Web_Api_Prac.Models.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
