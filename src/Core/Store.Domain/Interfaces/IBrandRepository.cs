using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IBrandRepository : IBaseRepository<DbContext, BaseFilter, Brand, Guid>
    {
        Task<Brand> GetByName(string name, CancellationToken cancellationToken = default);
    }
}
