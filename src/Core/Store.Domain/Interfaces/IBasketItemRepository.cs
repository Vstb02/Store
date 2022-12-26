using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IBasketItemRepository : IBaseRepository<BasketItem, Guid>
    {
    }
}
