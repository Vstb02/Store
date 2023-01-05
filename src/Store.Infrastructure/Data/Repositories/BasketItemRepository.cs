using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repositories
{
    public class BasketItemRepository : BaseRepository<ApplicationDbContext, BasketItem, Guid>,
        IBasketItemRepository
    {
        public BasketItemRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
