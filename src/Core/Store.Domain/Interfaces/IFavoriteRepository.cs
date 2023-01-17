using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IFavoriteRepository : IBaseRepository<BaseFilter, Favorite, Guid>
    {
        Task<Favorite> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default);
    }
}
