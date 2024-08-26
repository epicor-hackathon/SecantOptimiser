using SecantOptimiserAPI.Models;
using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;

namespace SecantOptimiserAPI.Services
{
    public class SecantOptimiserService : ISecantOptimiserService
    {
        //readonly IOptimiserRequestService _optimiserRequestService;
        readonly ISecFileService _secFileService;
        public SecantOptimiserService(ISecFileService secFileService)
        {
            //_optimiserRequestService = optimiserRequestService;
            _secFileService = secFileService;   
        }

        public OptimiserResponse Optimise(RequestModel inputModel)
        {
            string tempDir = Directory.GetCurrentDirectory() + @"\EpicorSecant\";
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            var tempFile = Path.Combine(tempDir, Guid.NewGuid().ToString("N") + ".sec");
            _secFileService.ToSecFile(inputModel, tempFile);
            var success = InvokeSecant.Call(tempDir, Path.GetFileNameWithoutExtension(tempFile));
            if (success)
            {
                OptimiserResponse optimiserResponse = _secFileService.ReadFromFile(tempFile);
                // To Do. Remove the below commented code to delete the files
                //if (File.Exists(tempFile))
                //{
                //    File.Delete(tempFile);
                //}
                return optimiserResponse;
            }
            else
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
                return null;
            }
        }
    }
}
