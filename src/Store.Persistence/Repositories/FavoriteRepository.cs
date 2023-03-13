using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Filters.Comments;
using Store.Domain.Filters.Products;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class FavoriteRepository : BaseRepository<FavoriteDbContext, BaseFilter, Favorite, Guid>, 
        IFavoriteRepository
    {
        private readonly FavoriteDbContext _context;

        public FavoriteRepository(FavoriteDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context;
        }

        public Task<Favorite> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default)
        {
            var result = _context.Favorites.Include(x => x.Products).FirstOrDefaultAsync(
                x => x.BuyerId.Equals(buyerId),
                cancellationToken);

            return result;
        }
    }
}
