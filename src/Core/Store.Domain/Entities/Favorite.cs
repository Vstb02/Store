using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Favorite : BaseEntity<Guid>
    {
        public string BuyerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
