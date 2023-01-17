using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Common.Identity;
using Store.Application.Interfaces;
using Store.Application.Models.Filters;
using Store.Application.Models.Brands;

namespace Store.WebAPI.Controllers
{
    public class BrandController : ApiControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brnadService)
        {
            _brandService = brnadService;
        }

        /// <summary>
        /// Создание новоой компании
        /// </summary>
        /// <param name="request"></param>
        /// <returns>New brand Id</returns>
        /// <response code="200">Success</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = $"{IdentityRoles.Admin}, {IdentityRoles.Operator}")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandDto request)
        {
            var result = await _brandService.Create(request);

            return Ok(result);
        }

        /// <summary>
        /// Получение списка компаний
        /// </summary>
        /// <returns>List BrandDto</returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        [HttpGet()]
        public async Task<IActionResult> GetPageItems([FromQuery] FilterPagingDto filterPaging)
        {
            var result = await _brandService.GetPageItems(filterPaging);

            return Ok(result);
        }

        /// <summary>
        /// Удаление компании
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        [Authorize(Roles = $"{IdentityRoles.Admin}, {IdentityRoles.Operator}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _brandService.Delete(id);

            return Ok("Товар успешно удален");
        }

        /// <summary>
        /// Изменение данных компании
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>BrandDto</returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        [Authorize(Roles = $"{IdentityRoles.Admin}, {IdentityRoles.Operator}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBrandDto request)
        {
            var result = await _brandService.Update(id, request);

            return Ok(result);
        }
    }
}
