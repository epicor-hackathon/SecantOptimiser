using SecantOptimiserAPI.Models;
using System.Text;

namespace SecantOptimiserAPI.Builders
{
    class CuttingDataRequestBuilder
    {
        public static string[] GetLines(RequestModel requestModel)
        {
            List<string> lines = new List<string>();
            foreach (var item in requestModel.cuttingData)
            {
                StringBuilder @string = new StringBuilder();
                @string.Append($"{item.quantityRequired},");
                @string.Append($"{item.overMake},");
                @string.Append($"{item.topLength + item.bottomLength},"); // Length
                @string.Append($"{item.mitreWidth},"); // width
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
                @string.Append($"{item.quantityFree},");
                @string.Append($",");
                @string.Append(",");
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
                @string.Append(",");
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
    }
}
