using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Models.Comments
{
    public record class CommentDto
    {
        public List<CommentItemDto> Items { get; init; }
        public int TotalQuantity { get; init; }
    }
}
