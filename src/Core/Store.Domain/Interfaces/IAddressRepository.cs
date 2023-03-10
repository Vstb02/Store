using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IAddressRepository : IBaseRepository<BaseFilter, Address, Guid>
    {
        Task<List<Address>> GetAddressesByBuyerId(string buyerId,
                                                  CancellationToken cancellationToken = default);
    }
}
