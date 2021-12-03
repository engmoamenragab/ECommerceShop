using ECommerceShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.DAL.Database
{
    public class ECommerceShopDbContext : DbContext
    {
        public ECommerceShopDbContext(DbContextOptions<ECommerceShopDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = .; Database = ECommerceShopDb; Integrated Security = True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>().HasKey(E => new { E.OrderId, E.ProductId });
            modelBuilder.Entity<OrderProduct>().HasOne(E => E.Order).WithMany(E => E.OrderProducts).HasForeignKey(E => E.OrderId);
            modelBuilder.Entity<OrderProduct>().HasOne(E => E.Product).WithMany(E => E.OrderProducts).HasForeignKey(E => E.ProductId);
        }
    }
}
