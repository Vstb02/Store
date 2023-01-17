using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Common.Identity;
using Store.Application.Interfaces;
using Store.Application.Models.Filters;
using Store.Application.Models.Products;
using Store.Domain.Identity;

namespace Store.WebAPI.Controllers
{
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Создание нового продукта
        /// </summary>
        /// <param name="request"></param>
        /// <returns>New product Id</returns>
        /// <response code="200">Success</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = $"{IdentityRoles.Admin}, {IdentityRoles.Operator}")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto request)
        {
            var result = await _productService.Create(request);

            return Ok(result);
        }

        /// <summary>
        /// Получение продукта по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProductDto</returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productService.GetById(id);

            return Ok(result);
        }

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <returns>List ProductDto</returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        public async Task<IActionResult> GetPageItems([FromQuery] FilterPagingDto filterPaging, [FromQuery] ProductFilterDto filter)
        {
            var result = await _productService.GetPageItems(filterPaging, filter);

            return Ok(result);
        }

        /// <summary>
        /// Удаление продукта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [Authorize(Roles = $"{IdentityRoles.Admin}, {IdentityRoles.Operator}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.Delete(id);

            return Ok("Товар успешно удален");
        }

        /// <summary>
        /// Изменение данных продукта
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ProductDto</returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [Authorize(Roles = $"{IdentityRoles.Admin}, {IdentityRoles.Operator}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto request)
        {
            var result = await _productService.Update(id, request);

            return Ok(result);
        }
    }
}
