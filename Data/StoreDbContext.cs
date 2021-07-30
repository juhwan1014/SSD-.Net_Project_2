using Microsoft.EntityFrameworkCore;
using SSDeShopOnWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSDeShopOnWeb.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartProduct>()
                .HasKey(cp => new { cp.CartId, cp.ProductId});

            modelBuilder.Entity<CartProduct>()
                .HasOne(cp=>cp.Cart)
                .WithMany(c=>c.CartProducts)
                .HasForeignKey(fk=>new { fk.CartId });

            modelBuilder.Entity<CartProduct>()
              .HasOne(cp => cp.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(fk => new { fk.ProductId });
        }
    }
}
