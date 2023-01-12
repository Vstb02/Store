using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;
using Store.Domain.Filters;

namespace Store.Infrastructure.Data.Repositories
{
    public class BrandRepository : BaseRepository<ApplicationDbContext, BaseFilter, Brand, Guid>,
        IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context; 
        }

        public async Task<Brand> GetByName(string name, CancellationToken cancellationToken = default)
        {
            var result = await _context.Brands.FirstOrDefaultAsync(x => x.Name.Equals(name),
                                                                   cancellationToken);

            return result;
        }
    }
}
