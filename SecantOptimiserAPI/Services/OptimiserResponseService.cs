using SecantOptimiserAPI.Models;
using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;

namespace SecantOptimiserAPI.Services
{
    public class OptimiserResponseService : IOptimiserResponseService
    {
        readonly IJobDataRequestService _jobDataService;
        readonly IStockDataRequestService _stockDataService;
        readonly ICuttingDataRequestService _cuttingDataService;
        readonly ISecantSection _secantSectionService;
        public OptimiserResponseService(IJobDataRequestService jobDataService, IStockDataRequestService stockDataService, ICuttingDataRequestService cuttingDataService, ISecantSection secantSectionService)
        {
            _jobDataService = jobDataService;
            _stockDataService = stockDataService;
            _cuttingDataService = cuttingDataService;   
            _secantSectionService = secantSectionService;
        }
        public OptimiserResponse GetOptimiserResponse(string path)
        {
            OptimiserResponse optimiserResponse = new OptimiserResponse();
            var lines = File.ReadAllLines(path);
            var sections = new List<SecantSection>();

            // split lines into sections each starting with section header
            var sectionLines = new List<string>();
            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("["))
                {
                    if (sectionLines.Count > 0)
                    {
                        sections.Add(_secantSectionService.ReadSection(sectionLines.ToArray()));
                        sectionLines = new List<string>();
                    }
                }
                sectionLines.Add(line);
            }
            if (sectionLines.Count > 0)
            {
                sections.Add(_secantSectionService.ReadSection(sectionLines.ToArray()));
            }
            foreach (var item in sections)
            {
                //switch (item.Name)
                //{
                //    case UtilityService.SEC_NAME_JOB:
                //         _jobDataService.GetOptimiserResponse(item);
                //        break;
                //    case UtilityService.SEC_NAME_CUT:
                //        _cuttingDataService.GetOptimiserResponse(optimiserResponse, item);
                //        break;
                //    case UtilityService.SEC_NAME_STK:
                //        _stockDataService.GetOptimiserResponse(item);
                //        break;
                //}
            }
            return optimiserResponse;
        }
    }
}
