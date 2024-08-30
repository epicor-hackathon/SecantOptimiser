using SecantOptimiserAPI.Models.Request;

namespace SecantOptimiserAPI.Models.Response
{
    public interface IPatternService
    {
        void BuildPatternData(RequestModel requestModel, SecantSection secant,ref OptimiserResponse optimiserResponse);
    }
}
