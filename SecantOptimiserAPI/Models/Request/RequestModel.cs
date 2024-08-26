namespace SecantOptimiserAPI.Models.Request
{
    public class RequestModel
    {
        public string jobNumber { get; set; }
        public List<CuttingData> cuttingData { get; set; }
        public List<StockData> StockData { get; set; }
        public CuttingOptions cuttingOptions { get; set; }
        public OptionalCuttingOptions optionalCuttingOptions { get; set; }
    }


}
