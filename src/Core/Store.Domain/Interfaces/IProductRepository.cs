using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<DbContext, Product, Guid>
    {
        Task<Product> GetByName(string name, CancellationToken cancellationToken = default);
    }
}
