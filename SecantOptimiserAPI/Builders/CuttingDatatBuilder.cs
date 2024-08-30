using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;
using SecantOptimiserAPI.Services;
using System.Text;
using static SecantOptimiserAPI.Models.Response.OptimiserResponse;

namespace SecantOptimiserAPI.Builders
{
    class CuttingDatatBuilder
    {
        public static string[] GetLines(RequestModel requestModel)
        {
            List<string> lines = new List<string>();
            foreach (var item in requestModel.cuttingData)
            {
                StringBuilder @string = new StringBuilder();
                @string.Append($"{item.quantityRequired},");
                @string.Append($"{item.overMake},");
                @string.Append($"{item.lengthInMm},");
                @string.Append(","); // width
                @string.Append($"{item.grain},");
                @string.Append($"{item.@class},");
                @string.Append($"{item.identifier},");
                @string.Append($"{item.material},");
                @string.Append($"{item.description},");
                @string.Append($"{item.formation},");
                @string.Append($"{item.stackHeight},");
                @string.Append($"{item.split},");
                @string.Append($"{item.type},");
                @string.Append($"{item.tie},");
                @string.Append(",");//Goods Free
                @string.Append($","); //Orig Demand
                @string.Append(","); //Orig Overmake
                @string.Append($"{item.edge},");
                @string.Append($"{item.segment},");
                @string.Append($"{item.batch},");
                @string.Append($"{item.batchLimit},");
                @string.Append($"{item.mitreCut},");
                @string.Append($"{item.mitreType},");
                @string.Append($"{item.topLength},");
                @string.Append($"{item.bottomLength},");
                @string.Append($"{item.rearAngle},");
                @string.Append($"{item.frontAngle},");
                @string.Append($"{item.mitreWidth},");
                @string.Append(","); //Face
                @string.Append($"{item.symmetrical}");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append(",");
                @string.Append("");
                lines.Add(@string.ToString());
            }

            return lines.ToArray();

        }

        public static OptimiserResponse BuildCuttingData(RequestModel requestModel, SecantSection secant)
        {
            OptimiserResponse optimiserResponse = new OptimiserResponse();
            foreach (var item in secant.Lines)
            {
                string[] values = item.Split(',');
                optimiserResponse.cutPieceData.Add(new CutPieceData()
                {
                    identifier = values[0],
                    description = values[1],
                    quantityMade = UtilityService.ConvertToInt(values[2]),
                    quantityRequired = UtilityService.ConvertToInt(values[3]),
                    quantityVariance = 0,
                    cutRequestRecordNumber = 0
                });
            }
            return optimiserResponse;
        }
    }
}
