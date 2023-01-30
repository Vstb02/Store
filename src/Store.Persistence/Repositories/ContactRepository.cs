using Microsoft.EntityFrameworkCore;
using Nest;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Repositories;
using Store.Persistence.Contexts;

namespace Store.Persistence.Repositories
{
    public class ContactRepository : BaseRepository<ApplicationDbContext, BaseFilter, Contact, Guid>,
        IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context, IElasticClient elasticClient)
            : base(context, elasticClient)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContactsByBuyerId(string buyerId,
                                           CancellationToken cancellationToken = default)
        {
            var result = await _context.Contacts.Where(x => x.BuyerId.Equals(buyerId))
                                                 .ToListAsync(cancellationToken);

            return result;
        }
    }
}
