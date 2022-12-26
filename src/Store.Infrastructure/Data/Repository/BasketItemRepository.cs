using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repository
{
    public class BasketItemRepository : BaseRepository<BasketItem, Guid>,
        IBasketItemRepository
    {
        public BasketItemRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
