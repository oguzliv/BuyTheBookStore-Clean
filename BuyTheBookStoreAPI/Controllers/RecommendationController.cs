using BuyTheBookStore.Application.Services.RecommendationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyTheBookStoreAPI.Controllers
{
    [Route("recommend")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }
        [Authorize]
        [HttpGet("{genre?}")]
        public async Task<object> Recommend([FromRoute] string? genre)
        {
            try
            {
                var recommendedBooks = await _recommendationService.RecommendBook(genre);
                if (recommendedBooks == null)
                    return BadRequest($"{genre} is Invalid Genre");
                else
                    return Ok(recommendedBooks);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
