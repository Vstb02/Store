using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Common.Exceptions;
using Store.Application.Common.Identity;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.WebAPI.Models;
using Store.WebAPI.Models.Categories;
using Store.WebAPI.Models.Products;

namespace Store.WebAPI.Controllers
{
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService,
                                 ILogger<ProductController> logger,
                                 IMapper mapper)
        {
            _productService = productService;
            _logger = logger;
            _mapper = mapper;
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
                var entity = _mapper.Map<Product>(request);

                var result = await _productService.Create(entity);

                return Ok(new Response<Guid>(200, result));
            }
            catch (DuplicateProductNameException ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке создать товар");
                return Conflict(new Response<Guid>(409, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке создать товар");
                return StatusCode(500, new Response<Guid>(500, "Произошла ошибка при попытке создать товар"));
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

                var entity = _mapper.Map<ProductDto>(result);

                return Ok(new Response<ProductDto>(200, entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке получить товар");
                return StatusCode(500, new Response<Guid>(500, "Произошла ошибка при попытке получить товар"));
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _productService.GetAll();

                var entities = _mapper.Map<List<ProductDto>>(result);

                return Ok(new Response<List<ProductDto>>(200, entities));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке получить список товаров товар");
                return StatusCode(500, new Response<Guid>(500, "Произошла ошибка при попытке получить список товаров товар"));
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

                return Ok(new Response<string>(200, "Товар успешно удален"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ФПроизошла ошибка при попытке удалить товар");
                return StatusCode(500, new Response<string>(500, "Произошла ошибка при попытке удалить товар"));
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
                var entity = await _productService.GetById(id);

                if (entity is null)
                {
                    _logger.LogError($"Категория с Id {id} не найдена");
                    return BadRequest(new Response<CategoryDto>(400, "Категория не найдена"));
                }

                _mapper.Map(request, entity);
                entity = await _productService.Update(entity);

                var result = _mapper.Map<ProductDto>(entity);

                return Ok(new Response<ProductDto>(200, result));
            }
            catch (DuplicateCategoryNameException ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке обновить товар");
                return Conflict(new Response<Guid>(409, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке обновить данные товара");
                return StatusCode(500, new Response<string>(500, "Произошла ошибка при попытке обновить данные товара"));
            }
        }
    }
}
