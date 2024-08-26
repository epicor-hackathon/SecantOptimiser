using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecantOptimiserAPI.Models;

namespace SecantOptimiserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecantOptimiserController : ControllerBase
    {
        readonly ISecantOptimiserService _secantOptimiserService;
        public SecantOptimiserController(ISecantOptimiserService secantOptimiserService)
        {
            _secantOptimiserService = secantOptimiserService;
        }
        [HttpPost(Name = "Optimise")]
        public IActionResult Post(RequestModel inputModel)
        {
            return Ok(_secantOptimiserService.Optimise(inputModel));
        }
    }
}
