using SecantOptimiserAPI.Builders;
using SecantOptimiserAPI.Models;

namespace SecantOptimiserAPI.Services
{
    public class JobDataRequestService: IJobDataRequestService
    {
        public string[] GetLines(RequestModel requestModel)
        {
            string[] lines = JobDataRequestBuilder.GetLines(requestModel);
            return lines;
        }
    }
}
