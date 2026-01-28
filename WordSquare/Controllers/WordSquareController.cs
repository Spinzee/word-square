using Microsoft.AspNetCore.Mvc;
using WordSquare.Services;

namespace WordSquare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordSquareController : ControllerBase
    {
        private readonly BuildSquareService _buildSquare;
        public WordSquareController(BuildSquareService buildSquare)
        {
            _buildSquare = buildSquare;
        }

        [HttpPost]
        public IActionResult Solve([FromBody] WordSquareRequest request)
        {
            if (!request.IsValid)
            {
                return BadRequest(new { error = "Request not valid. The letters supplied must match the grid size" });
            }

            var result = _buildSquare.Solve(request.Size, request.Letters);

            if (result?.Count == null)
            {
                return BadRequest(new { error = "No valid word square found" });
            }

            return Ok(new WordSquareResponse { Square = result });
        }
    }
}
