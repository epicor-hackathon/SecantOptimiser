using System.Runtime.CompilerServices;
using System.Text;

namespace SecantOptimiserAPI.Models
{
    public class CuttingData 
    {
        public string identifier { get; set; }
        public int lengthInMm { get; set; }
        public int widthInMm { get; set; }
        public int quantityRequired { get; set; }
        public int overMake { get; set; }
        public string grain { get; set; }
        public string @class { get; set; }
        public string material { get; set; }
        public string description { get; set; }
        public int formation { get; set; }
        public int stackHeight { get; set; }
        public int split { get; set; }
        public string type { get; set; }
        public int tie { get; set; }
        public int quantityFree { get; set; }
        public int quantityAllocated { get; set; }
        public int originalDemand { get; set; }
        public string edge { get; set; }
        public string segment { get; set; }
        public string batch { get; set; }
        public int batchLimit { get; set; }
        public int mitreCut { get; set; }
        public string mitreType { get; set; }
        public int topLength { get; set; }
        public int bottomLength { get; set; }
        public double rearAngle { get; set; }
        public double frontAngle { get; set; }
        public double mitreWidth { get; set; }
        public string crossSection { get; set; }
        public int symmetrical { get; set; }
        public static string[] GetLines(RequestModel requestModel)
        {
            List<string> lines = new List<string>();
            foreach (var item in requestModel.cuttingData)
            {
                StringBuilder @string = new StringBuilder();
                @string.Append($"{item.quantityRequired},");
                @string.Append($"{item.overMake},");
                @string.Append($"{item.topLength+item.bottomLength},"); // Length
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

        public static string GetSectionName()
        {
            return "CUT";
        }
    }
}
