using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repositories
{
    public class BasketRepository : BaseRepository<ApplicationDbContext, Basket, Guid>,
        IBasketRepository
    {
        private readonly ApplicationDbContext _context;

        public BasketRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Basket> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default)
        {
            var result = await _context.Baskets.Include(x => x.BasketItems)
                                               .ThenInclude(x => x.Product)
                                               .FirstOrDefaultAsync(x => x.BuyerId.Equals(buyerId),
                                                                    cancellationToken);

            return result;
        }
    }
}
