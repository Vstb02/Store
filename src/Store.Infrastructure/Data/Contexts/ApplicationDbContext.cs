using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infrastructure.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BasketConfiguration());
            builder.ApplyConfiguration(new BasketItemConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
        }
    }
}
