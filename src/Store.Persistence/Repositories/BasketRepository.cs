using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Domain.Filters;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;
using Nest;

namespace Store.Persistence.Repositories
{
    public class BasketRepository : BaseRepository<BasketDbContext, BaseFilter, Basket, Guid>,
        IBasketRepository
    {
        private readonly BasketDbContext _context;

        public BasketRepository(BasketDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context;
        }

        public Task<Basket> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default)
        {
            var result = _context.Baskets.Include(x => x.BasketItems)
                                               .ThenInclude(x => x.Product)
                                               .FirstOrDefaultAsync(x => x.BuyerId.Equals(buyerId),
                                                                    cancellationToken);

            return result;
        }
    }
}
