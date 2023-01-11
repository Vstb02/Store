using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IBasketRepository : IBaseRepository<DbContext, Basket, Guid>
    {
        Task<Basket> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default);
    }
}
