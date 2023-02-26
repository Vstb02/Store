using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Infrastructure.Base.Controllers;

namespace Store.WebAPI.Controllers
{
    public class SearchController : ApiControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        /// <summary>
        /// Поиск продуктов
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>Список продуктов</returns>
        [HttpGet("{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            var result = await _searchService.SearchAsync(keyword);

            return Ok(result);
        }
    }
}
