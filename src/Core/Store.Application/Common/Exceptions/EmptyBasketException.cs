using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Common.Exceptions
{
    public class EmptyBasketException
    {
        public EmptyBasketException()
            : base($"В корзине не может быть 0 товаров при оформлении заказа")
        {
        }
    }
}
