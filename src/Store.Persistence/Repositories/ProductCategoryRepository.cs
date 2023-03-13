using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductDbContext, BaseFilter, ProductCategory, Guid>,
        IProductCategoryRepository
    {
        private readonly ProductDbContext _context;

        public ProductCategoryRepository(ProductDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context;
        }

        public Task<ProductCategory> GetByName(string name, CancellationToken cancellationToken = default)
        {
            var result = _context.Categories.FirstOrDefaultAsync(x => x.Name.Equals(name));

            return result;
        }
    }
}
