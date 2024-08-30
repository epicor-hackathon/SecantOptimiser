using SecantOptimiserAPI.Models.Response;

namespace SecantOptimiserAPI.Models.Request
{
    public interface ICuttingDataService
    {
        string[] GetLines(RequestModel requestModel);

        OptimiserResponse BuildCuttingData(RequestModel requestModel, SecantSection secant);
    }
}
