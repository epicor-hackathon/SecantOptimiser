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
                List<List<string>> pRecords = GetPatterns(item.ToArray(), "p");
                int patternNumberRecordNumber = 1;// Need to discuss
                foreach (var pPatterns in pRecords)
                {
                    string patternRecord = pPatterns[0];
                    string[] values = patternRecord.Split(',');
                    string[] PRec = item.FirstOrDefault().Split(',');
                    string[] SRec = item[2].Split(',');
                    OptimiserResponse.CuttingPatternData cuttingPatternData = new OptimiserResponse.CuttingPatternData();
                    cuttingPatternData.patternNumber = UtilityService.ConvertToInt(PRec[1]);
                    cuttingPatternData.cutRequestRecordNumber = UtilityService.ConvertToInt(values[1]);
                    cuttingPatternData.patternNumberRecordNumber = patternNumberRecordNumber;
                    cuttingPatternData.identifier = values[6];
                    cuttingPatternData.material = PRec[4];
                    cuttingPatternData.stockLength = UtilityService.ConvertToInt(SRec[3]);
                    cuttingPatternData.stockWidth = UtilityService.ConvertToInt(SRec[4]);// Need to discuss

                    cuttingPatternData.stockUnit = ""; // Need to discuss
                    cuttingPatternData.numberOff = 0;
                    cuttingPatternData.panelsProduced = 0;
                    cuttingPatternData.panelLength = 0; // Need to discuss
                    


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