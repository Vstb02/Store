using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Models.Comments
{
    public record class CommentItemDto
    {
        public Guid Id { get; init; }
        public string Content { get; init; }
        public Guid ProductId { get; init; }
        public string AuthorId { get; init; }
        public DateTime Created { get; init; }
    }
}
