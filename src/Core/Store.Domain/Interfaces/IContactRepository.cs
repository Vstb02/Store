using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IContactRepository : IBaseRepository<BaseFilter, Contact, Guid>
    {
        Task<List<Contact>> GetContactsByBuyerId(string buyerId,
                                                 CancellationToken cancellationToken = default);
    }
}
