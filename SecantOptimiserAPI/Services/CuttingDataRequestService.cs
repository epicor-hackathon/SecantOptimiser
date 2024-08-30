using SecantOptimiserAPI.Builders;
using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;

namespace SecantOptimiserAPI.Services
{
    public class CuttingDataRequestService : ICuttingDataService
    {
        public OptimiserResponse BuildCuttingData(RequestModel requestModel, SecantSection secant)
        {
            OptimiserResponse optimiserResponse = CuttingDatatBuilder.BuildCuttingData(requestModel, secant);
            return optimiserResponse;
        }

        public string[] GetLines(RequestModel requestModel)
        {
            string[] lines = CuttingDatatBuilder.GetLines(requestModel);
            return lines;
        }
    }
}
