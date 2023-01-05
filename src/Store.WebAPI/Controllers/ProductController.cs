using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Common.Exceptions;
using Store.Application.Common.Identity;
using Store.Application.Interfaces;
using Store.Application.Models.Products;
using Store.Domain.Filters;

namespace Store.WebAPI.Controllers
{
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService,
                                 ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Создание нового продукта
        /// </summary>
        /// <param name="request"></param>
        /// <returns>New product Id</returns>
        /// <response code="200">Success</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto request)
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
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpGet]
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
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]FilterPagingDto filterPaging)
        {
            var result = await _productService.GetAll(filterPaging);

            return Ok(result);
        }

        /// <summary>
        /// Удаление продукта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpDelete]
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
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, UpdateProductDto request)
        {
            var result = await _productService.Update(id, request);

            return Ok(result);
        }
    }
}
