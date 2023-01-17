using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Common.Exceptions
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException()
            : base($"Товара нет на складе ")
        {
        }
    }
}
