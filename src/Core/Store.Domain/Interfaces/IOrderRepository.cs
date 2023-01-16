using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IOrderRepository : IBaseRepository<DbContext, BaseFilter, Order, Guid>
    {
    }
}
