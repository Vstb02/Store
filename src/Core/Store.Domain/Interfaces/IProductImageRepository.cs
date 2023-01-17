using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IProductImageRepository : IBaseRepository<BaseFilter, ProductImage, Guid>
    {
    }
}
