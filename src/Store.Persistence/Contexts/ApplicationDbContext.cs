using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Store.Domain.Entities;
using Store.Persistence.Configurations;

namespace Store.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IServiceProvider _services;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IServiceProvider services) 
            : base(options)
        {
            _services = services;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BasketConfiguration());
            builder.ApplyConfiguration(new BasketItemConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new FavoriteConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new RatingConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var elastic = _services.GetService<IElasticClient>();

            var changedEntries = ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Added);

            foreach (var entry in changedEntries)
            {
                var entityType = entry.Entity.GetType().ToString();

                if (entityType is Product)
                {
                    elastic.IndexDocument(entry);
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
