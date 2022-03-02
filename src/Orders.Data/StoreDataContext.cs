using Microsoft.EntityFrameworkCore;
using Orders.Data.Map;
using Orders.Domain.Models;
using System;

namespace Orders.Data
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext(DbContextOptions<StoreDataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=orders-database;User ID=SA;Password=yourStrong(!)Password", b =>
            {
                b.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
