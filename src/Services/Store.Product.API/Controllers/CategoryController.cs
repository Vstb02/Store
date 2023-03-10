using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Common.Identity;
using Store.Application.Interfaces;
using Store.Application.Models.Categories;
using Store.Application.Models.Filters;
using Store.Infrastructure.Base.Controllers;

namespace Store.Product.API.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        private readonly IProductCategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger,
                                  IProductCategoryService categoryService)
        {
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
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto request)
        {
            var result = await _categoryService.Create(request);

            return Ok(result);
        }

        /// <summary>
        /// Получение категории по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CategoryDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _categoryService.GetById(id);

            return Ok(result);
        }

        /// <summary>
        /// Получение списка категорий
        /// </summary>
        /// <returns>List CategoryDto</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetPageItems([FromQuery] FilterPagingDto filterPaging)
        {
            var result = await _categoryService.GetPageItems(filterPaging);

            return Ok(result);
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
        [Authorize(Roles = $"{IdentityRoles.Admin}, {IdentityRoles.Operator}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDto request)
        {
            var result = await _categoryService.Update(id, request);

            return Ok(result);
        }

        /// <summary>
        /// Удаление данных категории
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="400">Bad Request</response>
        /// <response code="200">Success</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = $"{IdentityRoles.Admin}, {IdentityRoles.Operator}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Delete(id);

            return Ok("Категория успешно удалена");
        }
    }
}
