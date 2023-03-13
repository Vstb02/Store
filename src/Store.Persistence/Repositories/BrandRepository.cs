using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Domain.Filters;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;
using Nest;

namespace Store.Persistence.Repositories
{
    public class BrandRepository : BaseRepository<ProductDbContext, BaseFilter, Brand, Guid>,
        IBrandRepository
    {
        private readonly ProductDbContext _context;

        public BrandRepository(ProductDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context; 
        }

        public Task<Brand> GetByName(string name, CancellationToken cancellationToken = default)
        {
            var result = _context.Brands.FirstOrDefaultAsync(x => x.Name.Equals(name), cancellationToken);

            return result;
        }
    }
}
