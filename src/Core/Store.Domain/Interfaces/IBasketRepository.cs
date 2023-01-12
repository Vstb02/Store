using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IBasketRepository : IBaseRepository<DbContext, BaseFilter, Basket, Guid>
    {
        Task<Basket> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default);
    }
}
