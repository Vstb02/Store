using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Filters
{
    public class FilterPaging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;
    }
}
