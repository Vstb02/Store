using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Filters.Products;

namespace Store.Domain.Interfaces
{
    public interface IRatingRepository : IBaseRepository<DbContext, BaseFilter, Rating, Guid>
    {
        Task<List<Rating>> GetByProductId(Guid productId, CancellationToken cancellationToken = default);
    }
}
