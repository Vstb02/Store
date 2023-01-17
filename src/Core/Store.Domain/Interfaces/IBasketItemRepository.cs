using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IBasketItemRepository : IBaseRepository<BaseFilter, BasketItem, Guid>
    {
    }
}
