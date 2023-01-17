﻿using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Добавление комментария к товару
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="commentDto"></param>
        /// <returns>CommentItemDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> AddComment([FromQuery]Guid productId, CreateCommentDto commentDto)
        {
            var result = await _commentService.AddComment(UserId, productId, commentDto);

            return Ok(result);
        }

        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> DeleteComment([FromQuery] Guid commentId)
        {
            await _commentService.DeleteComment(UserId, commentId);

            return Ok();
        }

        /// <summary>
        /// Получение списка комментариев к товару
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="filter"></param>
        /// <returns>List CommentItemDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetProductsComment([FromQuery] FilterPagingDto paging, [FromQuery] CommentFilterDto filter)
        {
            var result = await _commentService.GetProductComment(paging, filter);

            return Ok(result);
        }
    }
}