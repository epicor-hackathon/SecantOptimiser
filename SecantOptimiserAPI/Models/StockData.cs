using System.Text;

namespace SecantOptimiserAPI.Models
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
        public static string[] GetLines(RequestModel requestModel)
        {
            List<string> lines = new List<string>();
            foreach (var item in requestModel.StockData)
            {
                StringBuilder @string = new StringBuilder();
                @string.Append($"{item.lengthInMm},");
                @string.Append($"{item.widthInMm},");
                @string.Append($"{item.quantityAvailable},");
                @string.Append($"{item.value},");
                @string.Append($"{item.@class},");
                @string.Append($"{item.thickness},");
                @string.Append($"{item.identifier},");
                @string.Append($"{item.description},");
                @string.Append($"{item.batch},");
                @string.Append($"{item.opened},");
                @string.Append($"{item.pattern},");
                @string.Append($",");
                @string.Append($"{item.jobAllocated},");
                @string.Append($"{item.price},");
                @string.Append($"{item.weight},");
                @string.Append($"{item.costPerKg},");
                @string.Append($","); //N Length
                @string.Append($","); //N Width
                @string.Append($"{item.material},");
                @string.Append($","); //Procurement cost
                @string.Append($","); //Priority
                @string.Append($","); //Material A
                @string.Append($","); //Material B
                @string.Append($","); //Material C
                @string.Append($","); //Material D
                @string.Append($""); //Material E

                lines.Add(@string.ToString());
            }
            return lines.ToArray();
        }

        public static string GetSectionName()
        {
            return "STK";
        }
    }
}
