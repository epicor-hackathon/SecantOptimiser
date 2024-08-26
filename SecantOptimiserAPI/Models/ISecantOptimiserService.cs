using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;

namespace SecantOptimiserAPI.Models
{
    public interface ISecantOptimiserService
    {
        OptimiserResponse Optimise(RequestModel inputModel);
    }
}
