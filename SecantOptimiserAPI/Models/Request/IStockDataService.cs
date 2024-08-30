using SecantOptimiserAPI.Models.Response;

namespace SecantOptimiserAPI.Models.Request
{
    public interface IStockDataService
    {
        string[] GetLines(RequestModel requestModel);
        void BuildStockData(RequestModel requestModel, SecantSection secant, ref OptimiserResponse optimiserResponse);
    }
}
