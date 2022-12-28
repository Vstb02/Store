using Store.Domain.Entities;

namespace Store.Application.Interfaces
{
    public interface IProductCategoryService
    {
        Task<Guid> Create(ProductCategory category, CancellationToken cancellationToken = default);

        Task<ProductCategory> GetById(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<ProductCategory>> GetAll(CancellationToken cancellationToken = default);

        Task<ProductCategory> Update(ProductCategory category, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
    }
}
