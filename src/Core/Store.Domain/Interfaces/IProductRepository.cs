using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Filters.Products;

namespace Store.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<ProductFilter, Product, Guid>
    {
        Task<Product> GetByName(string name, CancellationToken cancellationToken = default);
    }
}
