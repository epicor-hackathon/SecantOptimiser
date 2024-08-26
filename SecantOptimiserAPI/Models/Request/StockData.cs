using System.Text;

namespace SecantOptimiserAPI.Models.Request
{
    public class StockData
    {
        public string identifier { get; set; }
        public int lengthInMm { get; set; }
        public int widthInMm { get; set; }
        public int quantityAvailable { get; set; }
        public int value { get; set; }
        public string @class { get; set; }
        public double thickness { get; set; }
        public double costPerKg { get; set; }
        public double weight { get; set; }
        public double price { get; set; }
        public double quantityAllocated { get; set; }
        public string batch { get; set; }
        public int pattern { get; set; }
        public int opened { get; set; }
        public string jobAllocated { get; set; }
        public string description { get; set; }
        public int length1InMm { get; set; }
        public string sepFlag { get; set; }
        public int length2InMm { get; set; }
        public string material { get; set; }
        public string unitId { get; set; }

    }
}
