using SecantOptimiserAPI.Builders;
using SecantOptimiserAPI.Models;

namespace SecantOptimiserAPI.Services
{
    public class StockDataRequestService : IStockDataRequestService
    {
        public string[] GetLines(RequestModel requestModel)
        {
            string[] lines = StockDataRequestBuilder.GetLines(requestModel);
            return lines;
        }
    }
}
