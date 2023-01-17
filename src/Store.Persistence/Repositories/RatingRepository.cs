using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class RatingRepository : BaseRepository<ApplicationDbContext, BaseFilter, Rating, Guid>,
        IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rating>> GetByProductId(Guid productId, CancellationToken cancellationToken = default)
        {
            var result = await _context.Ratings.Where(x => x.ProductId.Equals(productId)).ToListAsync();

            return result;
        }

        public async Task<Rating> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default)
        {
            var result = await _context.Ratings.FirstOrDefaultAsync(x => x.AuthorId.Equals(buyerId),
                                                                    cancellationToken);

            return result;
        }
    }
}
