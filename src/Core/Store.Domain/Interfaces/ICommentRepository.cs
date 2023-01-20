using Store.Domain.Entities;
using Store.Domain.Filters.Comments;

namespace Store.Domain.Interfaces
{
    public interface ICommentRepository : IBaseRepository<CommentFilter, Comment, Guid>
    {
    }
}
