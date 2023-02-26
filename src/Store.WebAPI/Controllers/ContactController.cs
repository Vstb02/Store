using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Application.Models.Contacts;
using Store.Infrastructure.Base.Controllers;

namespace Store.WebAPI.Controllers
{
    [Authorize]
    public class ContactController : ApiControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Получение контакта
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ContactDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(Guid id)
        {
            var result = await _contactService.GetContact(id);

            return Ok(result);
        }

        /// <summary>
        /// Получение списка контактов пользователя
        /// </summary>
        /// <returns>List ContactDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetContactsByBuyerId()
        {
            var result = await _contactService.GetContactsByBuyerId(UserId);

            return Ok(result);
        }

        /// <summary>
        /// Изменение данных контакта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>ContactDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] UpdateContactDto request)
        {
            var result = await _contactService.UpdateContact(id, request);

            return Ok(result);
        }

        /// <summary>
        /// Добавление нового контакта
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ContactDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] CreateContactDto request)
        {
            var result = await _contactService.AddContact(UserId, request);

            return Ok(result);
        }
    }
}
