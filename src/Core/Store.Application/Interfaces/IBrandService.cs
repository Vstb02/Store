using Store.Application.Models.Brands;
using Store.Application.Models.Filters;
using Store.Domain.Filters;

namespace Store.Application.Interfaces
{
    public interface IBrandService
    {
        Task<Guid> Create(CreateBrandDto brand, CancellationToken cancellationToken = default);
        Task<List<BrandDto>> GetPageItems(FilterPagingDto paging, BaseFilter filter = null, CancellationToken cancellationToken = default);
        Task<BrandDto> Update(Guid id, UpdateBrandDto brand, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
    }
}
