using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Brand : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
