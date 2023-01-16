using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Application.Models.Addresses;

namespace Store.WebAPI.Controllers
{
    public class AddressController : ApiControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        /// <summary>
        /// Получение адреса
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>AddressDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetAddress([FromQuery] Guid addressId)
        {
            var result = await _addressService.GetAddress(addressId);

            return Ok(result);
        }

        /// <summary>
        /// Получение списка адресов пользователя
        /// </summary>
        /// <returns>List AddressDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetAddresessByBuyerId()
        {
            var result = await _addressService.GetAddressesByBuyerId(UserId);

            return Ok(result);
        }

        /// <summary>
        /// Изменение данных адреса
        /// </summary>
        /// <param name="addressId"></param>
        /// <param name="request"></param>
        /// <returns>AddressDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> UpdateAddress([FromQuery] Guid addressId, UpdateAddressDto request)
        {
            var result = await _addressService.UpdateAddress(addressId, request);

            return Ok(result);
        }

        /// <summary>
        /// Добавление нового адреса
        /// </summary>
        /// <param name="request"></param>
        /// <returns>AddressDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> AddAddress(CreateAddressDto request)
        {
            var result = await _addressService.AddAdress(UserId, request);

            return Ok(result);
        }
    }
}
