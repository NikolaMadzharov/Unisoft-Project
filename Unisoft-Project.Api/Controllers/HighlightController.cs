using Microsoft.AspNetCore.Mvc;
using Unisoft_Project.Core.Contracts;
using Unisoft_Project.Core.Models;


namespace Unisoft_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighlightController : ControllerBase
    {
        private readonly IHighlightService _highlightService;

        public HighlightController(IHighlightService highlightService)
        {
            _highlightService = highlightService;
        }

        [HttpPost("completion-percentage")]
        public IActionResult CalculateCompletionPercentage([FromBody] List<HighlightRecord> passes)
        {
          
                var completionPercentage = _highlightService.CalculateCompletionPercentage(passes);

                return Ok(new
                {
                    CompletionPercentage = completionPercentage
                });
            
           
        }

        
        [HttpPost("longest-completed-pass")]
        public IActionResult FindLongestCompletedPass([FromBody] List<HighlightRecord> passes)
        {
            
                var longestCompletedPass = _highlightService.FindLongestCompletedPass(passes);
                return Ok(new
                {
                    LongestCompletedPass = longestCompletedPass
                });
           
        }
    }
}
