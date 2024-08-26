using SecantOptimiserAPI.Models;

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

            //_secFileService.WriteToFile(tempFile);
            var success = InvokeSecant.Call(tempDir, Path.GetFileNameWithoutExtension(tempFile));
            if (success)
            {
                _secFileService.ReadFromFile(tempFile);
                // To Do. Remove the below commented code to delete the files
                //if (File.Exists(tempFile))
                //{
                //    File.Delete(tempFile);
                //}
                return new OptimiserResponse(_secFileService);
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
