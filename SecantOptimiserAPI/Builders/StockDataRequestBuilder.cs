using SecantOptimiserAPI.Models.Request;
using System.Text;

namespace SecantOptimiserAPI.Builders
{
    class StockDataRequestBuilder
    {
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
    }
}
