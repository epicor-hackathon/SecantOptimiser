using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;
using SecantOptimiserAPI.Services;
using System.Text;

namespace SecantOptimiserAPI.Builders
{
    class StockDataBuilder
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
                @string.Append($"{item.length1InMm} ,"); //N Length
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

        public static void BuildStockData(RequestModel requestModel, SecantSection secant, ref OptimiserResponse optimiserResponse)
        {
            foreach (var item in secant.Lines)
            {
                string[] values = item.Split(',');

                string identifier = values[6];
                int lengthInMm = UtilityService.ConvertToInt(values[0]);
                //int quantityAvailable = UtilityService.ConvertToInt(values[2]);
                var sd = requestModel.StockData.FirstOrDefault(s => s.identifier.Equals(identifier, StringComparison.Ordinal) && s.lengthInMm.Equals(lengthInMm));
                //&& quantityAvailable.Equals(s.quantityAvailable));
                if (sd != null)
                {
                    OptimiserResponse.StockUsageData stockData = new OptimiserResponse.StockUsageData();
                    stockData.lengthInMm = lengthInMm;// UtilityService.ConvertToInt(values[0]);
                    stockData.widthInMm = UtilityService.ConvertToInt(values[1]);
                    stockData.quantityAvailable = UtilityService.ConvertToInt(values[2]);
                    stockData.value = UtilityService.ConvertToInt(values[3]);
                    stockData.@class = values[4];
                    stockData.thickness = UtilityService.ConvertToInt(values[5]);
                    stockData.identifier = identifier;// values[6];
                    stockData.description = values[7];
                    //stockData.batch = "X";// As per Secant doc this field is Not in use 
                    stockData.opened = UtilityService.ConvertToInt(values[9]);
                    stockData.pattern = UtilityService.ConvertToInt(values[10]);// Pattern : Need to discuss
                    stockData.quantityAllocated = UtilityService.ConvertToInt(values[11]);
                    stockData.jobAllocated = values[12];
                    stockData.price = UtilityService.ConvertToInt(values[13]);
                    stockData.weight = UtilityService.ConvertToInt(values[14]);
                    stockData.costPerKg = UtilityService.ConvertToInt(values[15]);
                    stockData.material = values[18];
                    stockData.length1InMm = sd.length1InMm; // Need to discuss
                    stockData.sepFlag = sd.sepFlag; // Need to discuss
                    stockData.length2InMm = sd.length2InMm; // Need to discuss
                    stockData.unitId = sd.unitId;
                    
                    optimiserResponse.stockUsageData.Add(stockData);
                }
            }
        }
    }
}
