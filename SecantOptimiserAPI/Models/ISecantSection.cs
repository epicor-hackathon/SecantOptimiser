using SecantOptimiserAPI.Services;

namespace SecantOptimiserAPI.Models
{
    public interface ISecantSection
    {
        void WriteSection(SecantSectionService section,StreamWriter writer);
        SecantSectionService ReadSection(string[] lines);
        public string Name { get; set; }
        public List<string> Lines { get; set; }
    }
}
