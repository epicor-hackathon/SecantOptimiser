using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;
using SecantOptimiserAPI.Services;

namespace SecantOptimiserAPI.Models
{
    public interface ISecFileService
    {
        void ToSecFile(RequestModel inputModel, string path);
        OptimiserResponse ReadFromFile(string path);

        SecantSection ReadSection(string[] lines);
    }
}
