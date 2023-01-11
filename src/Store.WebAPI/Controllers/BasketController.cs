using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;

namespace Store.WebAPI.Controllers
{
    public class BasketController : ApiControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        /// <summary>
        /// Добавление товара в корзину пользователя
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>New basket Id</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(Guid productId)
        {
            await _basketService.AddItemToBasket(UserId, productId);

            return Ok();
        }

        /// <summary>
        /// Получение корзины пользователя
        /// </summary>
        /// <returns>List basket items</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetBuyerBasket()
        {
            var result = await _basketService.GetBasketByBuyerId(UserId);

            return Ok(result);
        }

        /// <summary>
        /// Изменение количества товара в корзине
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        public async Task<IActionResult> SetQuantity(Guid productId, int quantity)
        {
            var result = await _basketService.SetQuantity(UserId, productId, quantity);

            return Ok(result);
        }

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete] 
        public async Task<IActionResult> DeleteItemFormBasket(Guid productId)
        {
            await _basketService.DeleteItemFromBasket(UserId, productId);

            return Ok();
        }
    }
}
