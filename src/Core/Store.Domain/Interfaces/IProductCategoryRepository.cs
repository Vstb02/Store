using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<BaseFilter, ProductCategory, Guid>
    {
        Task<ProductCategory> GetByName(string name, CancellationToken cancellationToken = default);
    }
}
