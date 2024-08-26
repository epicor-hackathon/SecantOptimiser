//using Microsoft.Extensions.Options;
//using SecantOptimiserAPI.Models;

//namespace SecantOptimiserAPI.Services;

//public class OptimiserRequestService : IOptimiserRequestService
//{
//    readonly ICuttingDataRequestService _cuttingDataRequestService;
//    readonly IStockDataRequestService _stockDataRequestService;
//    readonly ISecFileService _secFileService;
//    public OptimiserRequestService(ICuttingDataRequestService cuttingDataRequestService, IStockDataRequestService stockDataRequestService, ISecFileService secFileService)
//    {
//        _cuttingDataRequestService = cuttingDataRequestService;
//        _stockDataRequestService = stockDataRequestService;
//        _secFileService = secFileService;   
//    }
//    public void ToSecFile(RequestModel inputModel)
//    {
//        _secFileService.AddLinesToSection(UtilityService.SEC_NAME_CUT, _cuttingDataRequestService.GetLines(inputModel));
//        _secFileService.AddLinesToSection(UtilityService.SEC_NAME_STK, _stockDataRequestService.GetLines(inputModel));
//    }
//}
