using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(Guid addressId,
                         Guid contactId,
                         string buyerId,
                         CancellationToken cancellationToken = default);
    }
}
