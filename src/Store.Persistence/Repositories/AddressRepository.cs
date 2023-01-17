using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<ApplicationDbContext, BaseFilter, Address, Guid>,
        IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAddressesByBuyerId(string buyerId,
                                                               CancellationToken cancellationToken = default)
        {
            var result = await _context.Addresses.Where(x => x.BuyerId.Equals(buyerId))
                                                 .ToListAsync(cancellationToken);

            return result;
        }
    }
}
