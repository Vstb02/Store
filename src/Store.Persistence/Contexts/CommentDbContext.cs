using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Persistence.Configurations;

namespace Store.Persistence.Contexts
{
    public class CommentDbContext : DbContext
    {
        public CommentDbContext(DbContextOptions<CommentDbContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
