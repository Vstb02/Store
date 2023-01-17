using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Domain.Filters;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
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
