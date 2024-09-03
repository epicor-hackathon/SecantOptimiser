using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;
using SecantOptimiserAPI.Services;

namespace SecantOptimiserAPI.Builders
{
    class PatternResponseBuilder
    {
        public static void BuildPatterResponse(RequestModel requestModel, SecantSection secant, ref OptimiserResponse optimiserResponse)
        {
            List<List<string>> patterns = GetPatterns(secant.Lines.ToArray(), "P");
            foreach (var item in patterns)
            {
                string[] PRec = item.FirstOrDefault().Split(',');
                string[] SRec = item[2].Split(',');
                List<List<string>> pRecords = GetPatterns(item.ToArray(), "p");
                int patternNumberRecordNumber = 1;
                foreach (var pPatterns in pRecords)
                {
                    string patternRecord = pPatterns[0];
                    string[] pValues = patternRecord.Split(',');
                    
                    OptimiserResponse.CuttingPatternData cuttingPatternData = new OptimiserResponse.CuttingPatternData();
                    cuttingPatternData.patternNumber = UtilityService.ConvertToInt(PRec[1]);
                    cuttingPatternData.cutRequestRecordNumber = UtilityService.ConvertToInt(pValues[1]);
                    cuttingPatternData.patternNumberRecordNumber = patternNumberRecordNumber;
                    cuttingPatternData.identifier = pValues[6];
                    cuttingPatternData.material = PRec[4];
                    cuttingPatternData.stockLength = UtilityService.ConvertToInt(SRec[3]);
                    cuttingPatternData.stockWidth = UtilityService.ConvertToInt(SRec[4]);

                    cuttingPatternData.panelsProduced = 1; // Need to discuss
                    cuttingPatternData.numberOff = 1; // Need to discuss

                    var cutData = requestModel.cuttingData.FirstOrDefault(s => s.identifier.Equals(cuttingPatternData.identifier, StringComparison.Ordinal) &&
                        s.material.Equals(cuttingPatternData.material, StringComparison.Ordinal));
                    if (cutData != null)
                    {
                        cuttingPatternData.panelLength = cutData.lengthInMm;
                        var stockData = requestModel.StockData.FirstOrDefault(s => s.material.Equals(cuttingPatternData.material, StringComparison.Ordinal) && s.lengthInMm.Equals(cuttingPatternData.stockLength));
                        if (stockData != null)
                        {
                            cuttingPatternData.stockUnit = stockData.unitId;
                        }
                        
                    }
                    optimiserResponse.cuttingPatternData.Add(cuttingPatternData);
                    patternNumberRecordNumber++;
                }
            }

        }



        static List<List<string>> GetPatterns(string[] lines, string classification)
        {

            // List to hold each split group
            List<List<string>> groups = new List<List<string>>();
            List<string>? currentGroup = null;

            // Iterate through each line and split based on lines starting with classification
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith(classification, StringComparison.Ordinal))
                {
                    // Start a new group if a line starts with classification
                    currentGroup = new List<string>();
                    groups.Add(currentGroup);
                }

                // Add the line to the current group
                currentGroup?.Add(trimmedLine);
            }
            return groups;
        }
    }
}