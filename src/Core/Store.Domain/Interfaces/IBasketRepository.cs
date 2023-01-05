using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IBasketRepository : IBaseRepository<DbContext, Basket, Guid>
    {
    }
}
