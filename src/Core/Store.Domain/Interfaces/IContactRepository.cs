using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interfaces
{
    public interface IContactRepository : IBaseRepository<DbContext, BaseFilter, Contact, Guid>
    {
        Task<List<Contact>> GetContactsByBuyerId(string buyerId,
                                                  CancellationToken cancellationToken = default);
    }
}
