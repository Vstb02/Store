using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;
using System.Diagnostics;

namespace Store.Infrastructure.Data.Repositories
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
