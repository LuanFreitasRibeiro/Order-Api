using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Orders.Data
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<StoreDataContext>
    {
        public StoreDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreDataContext>();
            optionsBuilder.UseSqlServer("connectionString");

            return new StoreDataContext(optionsBuilder.Options);
        }
    }
}
