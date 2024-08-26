namespace SecantOptimiserAPI.Models
{
    public class JobData : ISecantInput
    {
        public string[] GetLines(RequestModel requestModel)
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
               ];
            return lines.ToArray();
        }

        public string GetSectionName()
        {
            return "JOB";
        }
    }
}
