using Store.Domain.Entities;
using Store.Domain.Filters.Comments;

namespace Store.Domain.Interfaces
{
    public interface ICommentRepository : IBaseRepository<CommentFilter, Comment, Guid>
    {
        Task<Comment> GetByAuthorId(string authorId, CancellationToken cancellationToken = default);
    }
}
