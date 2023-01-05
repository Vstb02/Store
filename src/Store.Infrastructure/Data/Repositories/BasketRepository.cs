using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repositories
{
    public class BasketRepository : BaseRepository<ApplicationDbContext, Basket, Guid>,
        IBasketRepository
    {
        public BasketRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
