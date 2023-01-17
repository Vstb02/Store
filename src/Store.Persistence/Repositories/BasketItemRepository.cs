using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class BasketItemRepository : BaseRepository<ApplicationDbContext, BaseFilter, BasketItem, Guid>,
        IBasketItemRepository
    {
        public BasketItemRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
