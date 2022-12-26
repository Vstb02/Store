using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repository
{
    public class BasketRepository : BaseRepository<Basket, Guid>,
        IBasketRepository
    {
        public BasketRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
