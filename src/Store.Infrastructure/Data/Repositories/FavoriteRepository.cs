using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repositories
{
    public class FavoriteRepository : BaseRepository<ApplicationDbContext, BaseFilter, Favorite, Guid>, 
        IFavoriteRepository
    {
        private readonly ApplicationDbContext _context;

        public FavoriteRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Favorite> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default)
        {
            var result = await _context.Favorites.Include(x => x.Products)
                                               .FirstOrDefaultAsync(x => x.BuyerId.Equals(buyerId),
                                                                    cancellationToken);

            return result;
        }
    }
}
