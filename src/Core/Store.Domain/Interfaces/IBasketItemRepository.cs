using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IBasketItemRepository : IBaseRepository<DbContext, BasketItem, Guid>
    {
    }
}
