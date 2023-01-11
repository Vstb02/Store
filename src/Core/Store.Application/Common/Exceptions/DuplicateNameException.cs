using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Common.Exceptions
{
    public class DuplicateNameException : Exception
    {
        public DuplicateNameException(string message, Guid duplicateItemId) : base(message)
        {
            DuplicateItemId = duplicateItemId;
        }

        public Guid DuplicateItemId { get; }
    }
}
