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
            try
            { 
                var result = await _productService.Create(request);

                return Ok(result);
            }
            catch (DuplicateProductNameException ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке создать товар");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке создать товар");
                return StatusCode(500, "Произошла ошибка при попытке создать товар");
            }
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
            try
            {
                var result = await _productService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке получить товар");
                return StatusCode(500, "Произошла ошибка при попытке получить товар");
            }
        }

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <returns>List ProductDto</returns>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Success</response>
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAll(FilterPagingDto filterPaging)
        {
            try
            {
                var result = await _productService.GetAll(filterPaging);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке получить список товаров товар");
                return StatusCode(500, "Произошла ошибка при попытке получить список товаров товар");
            }
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
            try
            {
                await _productService.Delete(id);

                return Ok("Товар успешно удален");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ФПроизошла ошибка при попытке удалить товар");
                return StatusCode(500, "Произошла ошибка при попытке удалить товар");
            }
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
            try
            {
                var result = await _productService.Update(id, request);

                return Ok(result);
            }
            catch (DuplicateProductNameException ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке обновить товар");
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке обновить данные товара");
                return StatusCode(500, "Произошла ошибка при попытке обновить данные товара");
            }
        }
    }
}
