using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<DbContext, BaseFilter, ProductCategory, Guid>
    {
        Task<ProductCategory> GetByName(string name, CancellationToken cancellationToken = default);
    }
}
