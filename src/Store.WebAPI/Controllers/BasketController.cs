using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;

namespace Store.WebAPI.Controllers
{
    [Authorize]
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
        /// <param name="id"></param>
        /// <returns>New basket Id</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("id")]
        public async Task<IActionResult> AddItemToBasket(Guid id)
        {
            await _basketService.AddItemToBasket(UserId, id);

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
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}/{quantity}")]
        public async Task<IActionResult> SetQuantity(Guid id, int quantity)
        {
            var result = await _basketService.SetQuantity(UserId, id, quantity);

            return Ok(result);
        }

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemFormBasket(Guid id)
        {
            await _basketService.DeleteItemFromBasket(UserId, id);

            return Ok();
        }
    }
}
