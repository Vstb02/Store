using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class RatingRepository : BaseRepository<RatingDbContext, BaseFilter, Rating, Guid>,
        IRatingRepository
    {
        private readonly RatingDbContext _context;

        public RatingRepository(RatingDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context;
        }

        public Task<List<Rating>> GetByProductId(Guid productId, CancellationToken cancellationToken = default)
        {
            var result = _context.Ratings.Where(x => x.ProductId.Equals(productId)).ToListAsync();

            return result;
        }

        public Task<Rating> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default)
        {
            var result = _context.Ratings.FirstOrDefaultAsync(x => x.AuthorId.Equals(buyerId), cancellationToken);

            return result;
        }
    }
}
