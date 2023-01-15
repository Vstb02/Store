using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Application.Models.Filters;

namespace Store.WebAPI.Controllers
{
    public class FavoriteController : ApiControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        /// <summary>
        /// Получение списка товаров в избранном
        /// </summary>
        /// <returns>List FavoriteItemDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetPageItems([FromQuery] FilterPagingDto paging)
        {
            var result = await _favoriteService.GetPageItems(UserId, paging);

            return Ok(result);
        }

        /// <summary>
        /// Добавление товара в избранное
        /// </summary>
        /// <returns>FavoriteItemDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> AddItemToBasket([FromQuery] Guid productId)
        {
            var result = await _favoriteService.AddItemToFavorite(UserId, productId);

            return Ok(result);
        }

        /// <summary>
        /// Удаление товара из избранного
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> RemoveItemToBasket([FromQuery] Guid productId)
        {
            await _favoriteService.RemoveItemToFavorite(UserId, productId);

            return Ok();
        }
    }
}
