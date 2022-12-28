using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory, Guid>,
        IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context)
            : base(context)
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
