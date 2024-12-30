using System.Data.Entity;

namespace ProductDetailProject.Models
{
    public class ServicesContext:DbContext
    {
        public DbSet<CategoryTable> CategoryTable { get; set; }
        public DbSet<ProductTable> ProductTable { get; set; }
    }
}