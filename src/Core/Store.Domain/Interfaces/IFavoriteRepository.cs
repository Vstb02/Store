using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IFavoriteRepository : IBaseRepository<DbContext, BaseFilter, Favorite, Guid>
    {
        Task<Favorite> GetByBuyerId(string buyerId, CancellationToken cancellationToken = default);
    }
}
