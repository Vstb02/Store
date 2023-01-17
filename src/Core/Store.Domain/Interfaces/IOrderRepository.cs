using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IOrderRepository : IBaseRepository<BaseFilter, Order, Guid>
    {
    }
}
