using Microsoft.EntityFrameworkCore;

namespace CoreWebAPIBackend.Core
{
    public class MyAppDBContext : DbContext
    {
        public MyAppDBContext(DbContextOptions<MyAppDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
