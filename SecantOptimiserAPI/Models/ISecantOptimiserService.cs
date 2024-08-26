namespace SecantOptimiserAPI.Models
{
    public interface ISecantOptimiserService
    {
        OptimiserResponse Optimise(RequestModel inputModel);
    }
}
