namespace SecantOptimiserAPI.Models.Request
{
    public interface IJobDataRequestService
    {
        string[] GetLines(RequestModel requestModel);
    }
}
