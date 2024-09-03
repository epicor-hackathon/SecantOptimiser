using SecantOptimiserAPI.Builders;
using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;

namespace SecantOptimiserAPI.Services
{
    public class PatternService : IPatternService
    {
        public void BuildPatternData(RequestModel requestModel, SecantSection secant, ref OptimiserResponse optimiserResponse)
        {
            PatternResponseBuilder.BuildPatterResponse(requestModel, secant, ref optimiserResponse);
        }
    }
}
