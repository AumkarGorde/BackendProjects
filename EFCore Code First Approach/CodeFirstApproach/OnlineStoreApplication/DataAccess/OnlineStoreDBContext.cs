using Microsoft.EntityFrameworkCore;
using OnlineStoreApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.DataAccess
{
    public class OnlineStoreDBContext:DbContext
    {
        public OnlineStoreDBContext(DbContextOptions<OnlineStoreDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProductMapping> OrderProductMappings { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships, if needed
            // For example, modelBuilder.Entity<Product>().HasMany(p => p.ProductCategories);
        }
    }
}
