using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Filters.Comments;

namespace Store.Domain.Interfaces
{
    public interface ICommentRepository : IBaseRepository<DbContext, CommentFilter, Comment, Guid>
    {
        Task<Comment> GetByAuthorId(string authorId, CancellationToken cancellationToken = default);
    }
}
