using Store.Application.Models.Products;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Application.Interfaces
{
    public interface IProductService
    {
        Task<Guid> Create(CreateProductDto product, CancellationToken cancellationToken = default );

        Task<ProductDto> GetById(Guid id, CancellationToken cancellationToken = default);

        Task<List<ProductDto>> GetAll(FilterPagingDto paging, CancellationToken cancellationToken = default);

        Task<ProductDto> Update(Guid id, UpdateProductDto product, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
    }
}
