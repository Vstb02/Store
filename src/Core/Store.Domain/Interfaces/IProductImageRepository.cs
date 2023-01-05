using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IProductImageRepository : IBaseRepository<DbContext, ProductImage, Guid>
    {
    }
}
