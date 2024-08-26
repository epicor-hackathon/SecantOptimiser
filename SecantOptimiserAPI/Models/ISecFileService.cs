using SecantOptimiserAPI.Services;

namespace SecantOptimiserAPI.Models
{
    public interface ISecFileService
    {
        void ToSecFile(RequestModel inputModel,string path);
        //void WriteToFile(string path);
        void AddLinesToSection(string sectionName, string[] lines);

        void ReadFromFile(string path);
        List<SecantSectionService> Sections { get; set; }
    }
}
