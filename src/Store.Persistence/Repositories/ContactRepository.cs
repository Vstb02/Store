using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class ContactRepository : BaseRepository<IdentityDbContext, BaseFilter, Contact, Guid>,
        IContactRepository
    {
        private readonly IdentityDbContext _context;

        public ContactRepository(IdentityDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context;
        }

        public Task<List<Contact>> GetContactsByBuyerId(string buyerId, CancellationToken cancellationToken = default)
        {
            var result = _context.Contacts.Where(x => x.BuyerId.Equals(buyerId))
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
