using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interfaces
{
    public interface IBrandRepository : IBaseRepository<DbContext, Brand, Guid>
    {
        Task<Brand> GetByName(string name, CancellationToken cancellationToken = default);
    }
}
