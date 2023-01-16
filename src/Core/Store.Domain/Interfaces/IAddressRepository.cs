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
    public interface IAddressRepository : IBaseRepository<DbContext, BaseFilter, Address, Guid>
    {
        Task<List<Address>> GetAddressesByBuyerId(string buyerId,
                                                  CancellationToken cancellationToken = default);
    }
}
