using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<OrderDbContext, BaseFilter, Order, Guid>,
        IOrderRepository
    {
        public OrderRepository(OrderDbContext context, IElasticClient elasticClient) 
            : base(context, elasticClient)
        {

        }
    }
}
