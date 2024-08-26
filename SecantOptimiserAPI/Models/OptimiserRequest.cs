using Microsoft.Extensions.Options;

namespace SecantOptimiserAPI.Models;

public class OptimiserRequest
{
    public CuttingData CData { get; set; }
    public StockData SData { get; set; }
    //public CuttingOptions CuttingOptions { get; set; }
    //public CuttingOverride? CuttingOverride { get; set; }

    public SecFile ToSecFile(RequestModel inputModel)
    {        
        var secFile = new SecFile();
        secFile.AddLinesToSection(CuttingData.GetSectionName(), CuttingData.GetLines(inputModel));  
        secFile.AddLinesToSection(StockData.GetSectionName(), StockData.GetLines(inputModel));
        //secFile.AddLinesToSection(CuttingOptions.GetSectionName(), CuttingOptions.GetLines());
        //if (CuttingOverride != null)
        //{
        //    secFile.AddLinesToSection(CuttingOverride.GetSectionName(), CuttingOverride.GetLines());
        //}
        return secFile;
    }
}
