using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IOrderItemRepository : IBaseRepository<DbContext, BaseFilter, OrderItem, Guid>
    {
    }
}
