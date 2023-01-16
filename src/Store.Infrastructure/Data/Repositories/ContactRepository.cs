using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;

namespace Store.Infrastructure.Data.Repositories
{
    public class ContactRepository : BaseRepository<ApplicationDbContext, BaseFilter, Contact, Guid>,
        IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetContactsByBuyerId(string buyerId,
                                           CancellationToken cancellationToken = default)
        {
            var result = await _context.Contacts.Where(x => x.BuyerId.Equals(buyerId))
                                                 .ToListAsync(cancellationToken);

            return result;
        }
    }
}
