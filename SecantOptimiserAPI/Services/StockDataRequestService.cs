using SecantOptimiserAPI.Builders;
using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;

namespace SecantOptimiserAPI.Services
{
    public class StockDataRequestService : IStockDataService
    {
        public void BuildStockData(RequestModel requestModel, SecantSection secant, ref OptimiserResponse optimiserResponse)
        {
            StockDataBuilder.BuildStockData(requestModel,secant, ref optimiserResponse);
        }

        public string[] GetLines(RequestModel requestModel)
        {
            string[] lines = StockDataBuilder.GetLines(requestModel);
            return lines;
        }
    }
}
