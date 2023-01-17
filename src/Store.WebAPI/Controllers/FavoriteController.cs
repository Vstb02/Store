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
        /// <param name="id"></param>
        /// <returns>FavoriteItemDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("{id}")]
        public async Task<IActionResult> AddItemToBasket(Guid id)
        {
            var result = await _favoriteService.AddItemToFavorite(UserId, id);

            return Ok(result);
        }

        /// <summary>
        /// Удаление товара из избранного
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveItemToBasket(Guid id)
        {
            await _favoriteService.RemoveItemToFavorite(UserId, id);

            return Ok();
        }
    }
}
