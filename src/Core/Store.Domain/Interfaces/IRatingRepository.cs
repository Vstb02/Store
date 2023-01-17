using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IRatingRepository : IBaseRepository<BaseFilter, Rating, Guid>
    {
        Task<IEnumerable<Rating>> GetByProductId(Guid productId, CancellationToken cancellationToken = default);
        Task<Rating> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default);
    }
}
