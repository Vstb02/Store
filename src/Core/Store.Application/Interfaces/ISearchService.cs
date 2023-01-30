using Store.Application.Models.Products;

namespace Store.Application.Interfaces
{
    public interface ISearchService
    {
        Task<List<ProductDto>> SearchAsync(string keyword, CancellationToken cancellationToken = default);
    }
}
