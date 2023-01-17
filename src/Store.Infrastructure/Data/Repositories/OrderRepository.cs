using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repositories
{
    public class OrderRepository : BaseRepository<ApplicationDbContext, BaseFilter, Order, Guid>,
        IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
