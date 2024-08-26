namespace SecantOptimiserAPI.Models
{
    public interface IStockDataRequestService
    {
        public string[] GetLines(RequestModel requestModel);
    }
}
