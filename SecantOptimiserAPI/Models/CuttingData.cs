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
       
    }
}
