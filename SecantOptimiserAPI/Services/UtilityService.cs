namespace SecantOptimiserAPI.Services
{
    public class UtilityService
    {
        public const string SEC_NAME_CUT = "CUT";
        public const string SEC_NAME_STK = "STK";
        public const string SEC_NAME_JOB = "JOB";
        public const string SEC_NAME_OVM = "OVM";
        public const string SEC_NAME_USD = "USD";
        public const string SEC_NAME_PAT = "PAT";

        public static int ConvertToInt(string strValue)
        {
            if (int.TryParse(strValue, out int result))
                return result;
            else if (double.TryParse(strValue, out double doubleResult))
                return (int)doubleResult;
            else return 0;
        }

    
    }
}
