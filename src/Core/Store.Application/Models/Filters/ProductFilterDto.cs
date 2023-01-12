using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Models.Filters
{
    public class ProductFilterDto
    {
        public Guid? Brand { get; set; }
        public Guid? Category { get; set; }
    }
}
