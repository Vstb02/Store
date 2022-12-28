using Store.Application.Models.Categories;

namespace Store.Application.Interfaces
{
    public interface IProductCategoryService
    {
        Task<Guid> Create(CreateCategoryDto category, CancellationToken cancellationToken = default);

        Task<CategoryDto> GetById(Guid id, CancellationToken cancellationToken = default);

        Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken = default);

        Task<CategoryDto> Update(Guid id, UpdateCategoryDto category, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
    }
}
