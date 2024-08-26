using SecantOptimiserAPI.Services;

namespace SecantOptimiserAPI.Models.Response
{
    public interface IOptimiserResponseService
    {
        OptimiserResponse GetOptimiserResponse(string path);
    }
}
