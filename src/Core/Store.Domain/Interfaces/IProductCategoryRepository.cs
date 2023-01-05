using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<DbContext, ProductCategory, Guid>
    {
        Task<ProductCategory> GetByName(string name, CancellationToken cancellationToken = default);
    }
}
