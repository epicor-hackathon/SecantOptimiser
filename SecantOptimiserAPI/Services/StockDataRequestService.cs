using SecantOptimiserAPI.Builders;
using SecantOptimiserAPI.Models.Request;

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
