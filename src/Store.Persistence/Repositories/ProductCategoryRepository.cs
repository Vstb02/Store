using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ApplicationDbContext, BaseFilter, ProductCategory, Guid>,
        IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context;
        }

        public async Task<ProductCategory> GetByName(string name, CancellationToken cancellationToken = default)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(x => x.Name.Equals(name));

            return result;
        }
    }
}
