using SecantOptimiserAPI.Services;

namespace SecantOptimiserAPI.Models
{
    public class OptimiserResponse
    {
        public List<CutPieceData> cutPieceData { get; set; }
        public List<CuttingPatternData> cuttingPatternData { get; set; }
        public List<StockUsageData> stockUsageData { get; set; }

        public OptimiserResponse()
        {
            // for json deserialisation
        }

        public OptimiserResponse(ISecFileService secFile)
        {
            // todo: implement output parsing from sec file sections SUM PAT OVM USD

        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class CutPieceData
        {
            public string identifier { get; set; }
            public string description { get; set; }
            public int quantityRequired { get; set; }
            public int quantityMade { get; set; }
            public int quantityVariance { get; set; }
            public int cutRequestRecordNumber { get; set; }
        }

        public class CuttingPatternData
        {
            public int cutRequestRecordNumber { get; set; }
            public int patternNumber { get; set; }
            public int patternNumberRecordNumber { get; set; }
            public string identifier { get; set; }
            public string material { get; set; }
            public int stockLength { get; set; }
            public string stockUnit { get; set; }
            public int numberOff { get; set; }
            public int panelsProduced { get; set; }
            public int panelLength { get; set; }
            public int stockWidth { get; set; }
        }

        public class StockUsageData
        {
            public string identifier { get; set; }
            public string material { get; set; }
            public int lengthInMm { get; set; }
            public int widthInMm { get; set; }
            public int quantityAvailable { get; set; }
            public int value { get; set; }
            public string @class { get; set; }
            public int thickness { get; set; }
            public int costPerKg { get; set; }
            public int weight { get; set; }
            public int price { get; set; }
            public int quantityAllocated { get; set; }
            public string batch { get; set; }
            public int pattern { get; set; }
            public int opened { get; set; }
            public string jobAllocated { get; set; }
            public string description { get; set; }
            public int length1InMm { get; set; }
            public string sepFlag { get; set; }
            public int length2InMm { get; set; }
            public string unitId { get; set; }
        }



    }
}
