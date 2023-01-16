using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Enums
{
    public enum OrderStatus
    {
        none,
        inProcessing,
        inTransit,
        delivered,
        canceled,
    }
}
