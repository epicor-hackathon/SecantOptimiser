namespace SecantOptimiserAPI.Models
{
    public class OptimiserResponse
    {
        public OptimiserResponse()
        {
            // for json deserialisation
        }

        public OptimiserResponse(SecFile secFile)
        {
            // todo: implement output parsing from sec file sections SUM PAT OVM USD
            throw new NotImplementedException();
        }

    }
}
