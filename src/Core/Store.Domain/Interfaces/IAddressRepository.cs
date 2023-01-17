﻿using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;

namespace Store.Domain.Interfaces
{
    public interface IAddressRepository : IBaseRepository<DbContext, BaseFilter, Address, Guid>
    {
        Task<IEnumerable<Address>> GetAddressesByBuyerId(string buyerId,
                                                  CancellationToken cancellationToken = default);
    }
}
