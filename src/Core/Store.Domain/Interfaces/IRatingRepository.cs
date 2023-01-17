using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IRatingRepository : IBaseRepository<DbContext, BaseFilter, Rating, Guid>
    {
        Task<IEnumerable<Rating>> GetByProductId(Guid productId, CancellationToken cancellationToken = default);
    }
}
