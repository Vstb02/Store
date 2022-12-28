using Store.Domain.Entities;

namespace Store.Application.Interfaces
{
    public interface IProductService
    {
        Task<Guid> Create(Product product, CancellationToken cancellationToken = default );

        Task<Product> GetById(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken = default);

        Task<Product> Update(Product product, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
    }
}
