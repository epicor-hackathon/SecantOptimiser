namespace SecantOptimiserAPI.Models.Request
{
    public interface ICuttingDataRequestService
    {
        string[] GetLines(RequestModel requestModel);
    }
}
