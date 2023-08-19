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
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships, if needed
            // For example, modelBuilder.Entity<Product>().HasMany(p => p.ProductCategories);
            #region Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductID);
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductID)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newid())");
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderProductMappings)
                .WithOne(op => op.Product);
            #endregion

            #region Category
            modelBuilder.Entity<Category>()
               .HasKey(c => c.CategoryID);
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryID)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newid())");
            modelBuilder.Entity<Category>()
                .HasMany(pc => pc.ProductCategories)
                .WithOne(pc=>pc.Category);
            #endregion

            #region Customer
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);
            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerID)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newid())");
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer);
            modelBuilder.Entity<Customer>()
               .HasOne<Address>(a => a.Address)
               .WithOne(c => c.Customer)
               .HasForeignKey<Address>(c => c.AddressID)
               .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Order
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderID);
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderID)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newid())");
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(op => op.Order);
            #endregion

            #region OrderProductMapping
            modelBuilder.Entity<OrderProductMapping>()
                .HasKey(op => op.OrderProductMappingID);
            modelBuilder.Entity<OrderProductMapping>()
                .Property(o => o.OrderProductMappingID)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newid())");
            modelBuilder.Entity<OrderProductMapping>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderID);
            modelBuilder.Entity<OrderProductMapping>()
                .HasOne(op=>op.Product)
                .WithMany(p => p.OrderProductMappings)
                .HasForeignKey(op => op.ProductID);
            #endregion

            #region Address
            modelBuilder.Entity<Address>()
               .HasKey(p => p.AddressID);
            modelBuilder.Entity<Address>()
               .Property(p => p.AddressID)
               .IsRequired()
               .HasColumnType("uniqueidentifier")
               .HasDefaultValueSql("(newid())");
            modelBuilder.Entity<Address>()
                .HasOne<Customer>(a => a.Customer)
                .WithOne(c=>c.Address)
                .HasForeignKey<Address>(ad=>ad.CustomerID);
            #endregion

            #region ProductCategory
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductID, pc.CategoryID }); // Composite primary key
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(p=>p.ProductID);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc=>pc.Category)
                .WithMany(c=>c.ProductCategories)
                .HasForeignKey(c=>c.CategoryID);
            #endregion


        }
    }
}
