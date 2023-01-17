using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Application.Models.Raitings;
using Store.Application.Models.Ratings;
using Store.Domain.Entities;

namespace Store.WebAPI.Controllers
{
    public class RatingController : ApiControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// Получение рейтинга товара
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProductRatingDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductRating(Guid id)
        {
            var result = await _ratingService.GetProductRating(id);

            return Ok(result);
        }

        /// <summary>
        /// Добавление рейтинга для товара
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rating"></param>
        /// <returns>RatingDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("{id}")]
        public async Task<IActionResult> AddRating(Guid id, [FromBody] CreateRatingDto rating)
        {
            var result = await _ratingService.AddRating(UserId, rating, id);

            return Ok(result);
        }

        /// <summary>
        /// Изменение рейтинга товара
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rating"></param>
        /// <returns>RatingDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> SetRating(Guid id, CreateRatingDto rating)
        {
            var result = await _ratingService.SetRating(UserId, rating, id);

            return Ok(result);
        }
    }
}
