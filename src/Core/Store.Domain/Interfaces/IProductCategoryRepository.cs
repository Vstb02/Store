using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory, Guid>
    {
    }
}
