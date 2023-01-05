using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Store.Infrastructure.Data.Repositories
{
    public class ProductRepository : BaseRepository<ApplicationDbContext, Product, Guid>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) 
            : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetByName(string name, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Name.Equals(name), cancellationToken);

            return entity;
        }

        public override async Task<List<Product>> GetPageItems(FilterPagingDto paging, CancellationToken cancellationToken = default)
        {
            var query = _context.Products.Include(x => x.ProductImages);
            var pagingQuery = ApplyPaging(query, paging);
            var data = await pagingQuery.ToListAsync(cancellationToken);

            return data;
        }
    }
}
