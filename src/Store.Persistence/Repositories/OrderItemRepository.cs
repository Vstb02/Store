using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderDbContext, BaseFilter, OrderItem, Guid>,
        IOrderItemRepository
    {
        public OrderItemRepository(OrderDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {

        }
    }
}
