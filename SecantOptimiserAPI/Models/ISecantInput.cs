namespace SecantOptimiserAPI.Models
{
    public interface ISecantInput
    {
        public string[] GetLines(RequestModel requestModel);
        public string GetSectionName();
    }
}
