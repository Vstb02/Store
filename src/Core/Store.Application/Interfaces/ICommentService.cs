

using Store.Application.Models.Comments;
using Store.Application.Models.Filters;

namespace Store.Application.Interfaces
{
    public interface ICommentService
    {
        Task<CommentItemDto> AddComment(string authorId,
                                        Guid productId,
                                        CreateCommentDto createComment,
                                        CancellationToken cancellationToken = default);

        Task DeleteComment(string authorId,
                           Guid commentId,
                           CancellationToken cancellationToken = default);

        Task<CommentDto> GetProductComment(FilterPagingDto paging,
                                           CommentFilterDto filter,
                                           CancellationToken cancellationToken = default);
    }
}
