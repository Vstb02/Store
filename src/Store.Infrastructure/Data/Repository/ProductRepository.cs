using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repository
{
    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) 
            : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetByName(string name, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Name.Equals(name));

            return entity;
        }

        public async new Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken = default)
        {
            var entities = await _context.Products.Include(x => x.ProductImages).ToListAsync();

            return entities;
        }
    }
}
