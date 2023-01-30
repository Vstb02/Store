using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Filters.Products;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<ApplicationDbContext, ProductFilter, Product, Guid>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IElasticClient _elasticClient;
        public ProductRepository(ApplicationDbContext context, IElasticClient elasticClient) 
            : base(context, elasticClient)
        {
            _context = context;
            _elasticClient = elasticClient;
        }

        public async Task<Product> GetByName(string name, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Name.Equals(name), cancellationToken);

            return entity;
        }

        public override async Task<IEnumerable<Product>> GetPageItems(FilterPaging paging,
                                                             ProductFilter filter,
                                                             CancellationToken cancellationToken = default)
        {
            var query = _context.Products.Include(x => x.ProductImages)
                                         .Include(x => x.Brand)
                                         .AsNoTracking();

            query = ApplyPaging(query, paging);
            query = ApplyFilter(query, filter);

            var data = await query.ToListAsync(cancellationToken);
            return data;
        }

        protected override IQueryable<Product> ApplyFilter(IQueryable<Product> result, ProductFilter filter)
        {
            result = filter.Brand is not null 
                ? result.Where(x => x.BrandId == filter.Brand) 
                : result;

            result = filter.Category is not null 
                ? result.Where(x => x.CategoryId == filter.Category) 
                : result;

            return result;
        }
    }
}
