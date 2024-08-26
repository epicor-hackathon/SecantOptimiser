namespace SecantOptimiserAPI.Models
{
    public class CuttingOptions
    {
        public int minimumOffcutLengthToStock { get; set; }
        public int sawTolerance { get; set; }
        public int numberOfLengths { get; set; }
        public int clampWidth { get; set; }
        public int maximumDifferentCutLengths { get; set; }
        public int optimiserSpeed { get; set; }
        public int maximumPiecesEx1Bar { get; set; }
        public int leftFrontTrim { get; set; }
        public int rightBackTrim { get; set; }
        public string mitreCuttingIndicator { get; set; }
        public double mitreAngle1 { get; set; }
        public double mitreAngle2 { get; set; }
        public int mitreClampWidth { get; set; }
      
    }
}
