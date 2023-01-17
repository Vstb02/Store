using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Application.Models.Orders;

namespace Store.WebAPI.Controllers
{
    public class OrderController : ApiControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="addressId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("{addressId}/{contactId}")]
        public async Task<IActionResult> CreateOrder(Guid addressId, Guid contactId)
        {
            await _orderService.CreateOrder(addressId, contactId, UserId);

            return Ok();
        }

        /// <summary>
        /// Изменение статуса заказа
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeOrderStatus(Guid id, [FromBody] ChangeOrderDto request)
        {
            await _orderService.ChangeStatusOrder(id, request);

            return Ok();
        }
    }
}
