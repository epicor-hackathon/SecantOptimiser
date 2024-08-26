namespace SecantOptimiserAPI.Models.Request
{
    public interface IStockDataRequestService
    {
        public string[] GetLines(RequestModel requestModel);
    }
}
