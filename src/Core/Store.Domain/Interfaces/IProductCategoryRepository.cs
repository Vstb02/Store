using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory, Guid>
    {
        Task<ProductCategory> GetByName(string name, CancellationToken cancellationToken = default);
    }
}
