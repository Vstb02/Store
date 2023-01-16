using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Application.Models.Comments;
using Store.Application.Models.Filters;
using Store.Domain.Filters.Comments;

namespace Store.WebAPI.Controllers
{
    public class CommentController : ApiControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromQuery]Guid productId, CreateCommentDto commentDto)
        {
            var result = await _commentService.AddComment(UserId, productId, commentDto);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment([FromQuery] Guid commentId)
        {
            await _commentService.DeleteComment(UserId, commentId);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsComment([FromQuery] FilterPagingDto paging, [FromQuery] CommentFilterDto filter)
        {
            var result = await _commentService.GetProductComment(paging, filter);

            return Ok(result);
        }
    }
}
