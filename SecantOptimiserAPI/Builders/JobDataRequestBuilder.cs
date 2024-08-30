using SecantOptimiserAPI.Models.Request;

namespace SecantOptimiserAPI.Builders
{
    class JobDataRequestBuilder
    {
        public static string[] GetLines(RequestModel requestModel)
        {
            List<string> lines =
               [
               "{Automatic}"
                ,"Incomplete=ko"
                ,"{status}"
                ,"{Job}"
                ,"Rangename=SecFile"
                ,"{defaults}"
                ,"name=Template"
                ,$"description={requestModel.jobNumber}"
               ];
            return lines.ToArray();
        }
    }
}
