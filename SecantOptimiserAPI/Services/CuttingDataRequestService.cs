using SecantOptimiserAPI.Builders;
using SecantOptimiserAPI.Models;

namespace SecantOptimiserAPI.Services
{
    public class CuttingDataRequestService : ICuttingDataRequestService
    {
        public string[] GetLines(RequestModel requestModel)
        {
            string[] lines = CuttingDataRequestBuilder.GetLines(requestModel);
            return lines;
        }
    }
}
