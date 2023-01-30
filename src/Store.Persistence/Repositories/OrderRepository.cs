using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<ApplicationDbContext, BaseFilter, Order, Guid>,
        IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context, IElasticClient elasticClient) 
            : base(context, elasticClient)
        {

        }
    }
}
