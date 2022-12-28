using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Common.Exceptions;
using Store.Application.Common.Identity;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.WebAPI.Models;
using Store.WebAPI.Models.Categories;

namespace Store.WebAPI.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        private readonly IProductCategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IMapper mapper,
                                  ILogger<CategoryController> logger,
                                  IProductCategoryService categoryService)
        {
            _mapper = mapper;
            _logger = logger;
            _categoryService = categoryService;
        }

        /// <summary>
        /// Создание категории
        /// </summary>
        /// <returns>New category Id</returns>
        /// <response code="200">Success</response>
        /// <response code="409">Conflict</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto request)
        {
            try
            {
                var entity = _mapper.Map<ProductCategory>(request);

                var result = await _categoryService.Create(entity);

                return Ok(new Response<Guid>(200, result));
            }
            catch (DuplicateCategoryNameException ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке создать категорию");
                return StatusCode(500, new Response<Guid>(500, "Произошла ошибка при попытке создать категорию"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке создать категорию");
                return Conflict(new Response<Guid>(409, ex.Message));
            }
        }

        /// <summary>
        /// Получение категории по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CategoryDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _categoryService.GetById(id);

                var entity = _mapper.Map<CategoryDto>(result);

                return Ok(new Response<CategoryDto>(200, entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке получить категорию");
                return StatusCode(500, new Response<Guid>(500, "Произошла ошибка при попытке получить категорию"));
            }
        }

        /// <summary>
        /// Получение списка категорий
        /// </summary>
        /// <returns>List CategoryDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _categoryService.GetAll();

                var entities = _mapper.Map<List<CategoryDto>>(result);

                return Ok(new Response<List<CategoryDto>>(200, entities));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке получить список категорий");
                return StatusCode(500, new Response<Guid>(500, "Произошла ошибка при попытке получить список категорий"));
            }
        }

        /// <summary>
        /// Обновление данных категории
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>CategoryDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryDto request)
        {
            try
            {
                var entity = await _categoryService.GetById(id);

                if (entity is null)
                {
                    _logger.LogError($"Категория с Id {id} не найдена");
                    return BadRequest(new Response<CategoryDto>(400, "Категория не найдена"));
                }

                _mapper.Map(request, entity);
                entity = await _categoryService.Update(entity);

                var result = _mapper.Map<CategoryDto>(entity);

                return Ok(new Response<CategoryDto>(200, result));
            }
            catch (DuplicateCategoryNameException ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке обновить категорию");
                return Conflict(new Response<Guid>(409, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке обновить категорию");
                return StatusCode(500, new Response<Guid>(500, "Произошла ошибка при попытке обновить категорию"));
            }
        }

        /// <summary>
        /// Удаление данных категории
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="400">Bad Request</response>
        /// <response code="200">Success</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = IdentityRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _categoryService.Delete(id);

                return Ok(new Response<string>(200, "Категория успешно удалена"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при попытке удалить категорию");
                return StatusCode(500, new Response<Guid>(500, "Произошла ошибка при попытке удалить категорию"));
            }
        }
    }
}
