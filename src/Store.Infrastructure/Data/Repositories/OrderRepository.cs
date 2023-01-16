using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Interfaces;
using Store.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data.Repositories
{
    public class OrderRepository : BaseRepository<ApplicationDbContext, BaseFilter, Order, Guid>,
        IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
