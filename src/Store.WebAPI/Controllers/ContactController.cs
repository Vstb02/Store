using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Application.Models.Contacts;

namespace Store.WebAPI.Controllers
{
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
        /// <param name="contactId"></param>
        /// <returns>ContactDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetContact([FromQuery] Guid contactId)
        {
            var result = await _contactService.GetContact(contactId);

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
        /// <param name="contactId"></param>
        /// <param name="request"></param>
        /// <returns>ContactDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> UpdateContact([FromQuery] Guid contactId, UpdateContactDto request)
        {
            var result = await _contactService.UpdateContact(contactId, request);

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
        public async Task<IActionResult> AddContact(CreateContactDto request)
        {
            var result = await _contactService.AddContact(UserId, request);

            return Ok(result);
        }
    }
}
