using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Contexts
{
    public class RatingDbContext : DbContext
    {
        public RatingDbContext(DbContextOptions<RatingDbContext> options) : base(options)
        {
        }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
        }
    }
}
