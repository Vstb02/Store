using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IContactRepository : IBaseRepository<DbContext, BaseFilter, Contact, Guid>
    {
        Task<IEnumerable<Contact>> GetContactsByBuyerId(string buyerId,
                                                  CancellationToken cancellationToken = default);
    }
}
