using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<IdentityDbContext, BaseFilter, Address, Guid>,
        IAddressRepository
    {
        private readonly IdentityDbContext _context;
        public AddressRepository(IdentityDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context;
        }

        public Task<List<Address>> GetAddressesByBuyerId(string buyerId, CancellationToken cancellationToken = default)
        {
            var result = _context.Addresses.Where(x => x.BuyerId.Equals(buyerId))
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
