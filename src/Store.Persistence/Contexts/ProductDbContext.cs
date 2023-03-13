using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Contexts
{
    public class ProductDbContext : DbContext
    {
        private readonly IElasticClient _elastic;
        public ProductDbContext(DbContextOptions<ProductDbContext> options, IElasticClient elastic) 
            : base(options)
        {
            _elastic = elastic;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var changedEntries = ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Added);

            foreach (var entry in changedEntries)
            {
                var entityType = entry.Entity.GetType().ToString();

                if (entityType is Product)
                {
                    _elastic.IndexDocument(entry);
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
