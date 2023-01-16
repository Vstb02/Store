using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Filters.Comments
{
    public class CommentFilter : BaseFilter
    {
        public Guid? Product { get; set; }
    }
}
