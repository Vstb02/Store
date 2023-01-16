using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Models.Comments;
using Store.Application.Models.Filters;
using Store.Domain.Entities;
using Store.Domain.Filters;
using Store.Domain.Filters.Comments;
using Store.Domain.Identity;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CommentService(ICommentRepository commentRepository,
                              IProductRepository productRepository,
                              IMapper mapper)
        {
            _commentRepository = commentRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CommentItemDto> AddComment(string authorId, 
                                               Guid productId,
                                               CreateCommentDto createComment,
                                               CancellationToken cancellationToken = default)
        {
            var existingProduct = await _productRepository.GetById(productId);

            if (existingProduct is null)
            {
                throw new NotFoundException("Товар не найден");
            }

            var comment = _mapper.Map<Comment>(createComment);
            comment.AuthorId = authorId;

            comment = await _commentRepository.Create(comment, cancellationToken);

            var result = _mapper.Map<CommentItemDto>(comment);

            return result;
        }

        public async Task DeleteComment(string authorId,
                                        Guid commentId,
                                        CancellationToken cancellationToken = default)
        {
            var comment = await _commentRepository.GetByAuthorId(authorId, cancellationToken);

            if (comment is null)
            {
                throw new NotFoundException("Комментарий не найден");
            }

            await _commentRepository.Delete(comment.Id, cancellationToken);
        }

        public async Task<CommentDto> GetProductComment(FilterPagingDto paging,
                                                        CommentFilterDto filter,
                                                        CancellationToken cancellationToken = default)
        {
            var pagingFilter = _mapper.Map<FilterPaging>(paging);
            var commentFilter = _mapper.Map<CommentFilter>(filter);

            var existingComments = await _commentRepository.GetPageItems(pagingFilter,
                                                                   commentFilter,
                                                                   cancellationToken);

            var comments = _mapper.Map<List<CommentItemDto>>(existingComments);

            var result = new CommentDto()
            {
                Items = comments,
                TotalQuantity = comments.Count
            };

            return result;
        }
    }
}
