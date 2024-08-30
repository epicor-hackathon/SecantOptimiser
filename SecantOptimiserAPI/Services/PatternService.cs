using SecantOptimiserAPI.Builders;
using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;

namespace SecantOptimiserAPI.Services
{
    public class PatternService : IPatternService
    {
        public void BuildPatternData(RequestModel requestModel, SecantSection secant, ref OptimiserResponse optimiserResponse)
        {
            PatternResponseBuilder.BuildPatterResponse(requestModel,secant, ref optimiserResponse);
        }

        /*
        private static void Sample1(SecantSection section)
        {
            var patternData = new List<string[]>();

            foreach (var line in section.Lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var fields = line.Split(',');
                    patternData.Add(fields);
                }
            }

            // Process the data
            foreach (var record in patternData)
            {
                switch (record[0])
                {
                    case "P":
                        ProcessPRecord(record);
                        break;
                    case "X":
                        ProcessXRecord(record);
                        break;
                    case "S":
                        ProcessSRecord(record);
                        break;
                    case "p":
                        ProcesspRecord(record);
                        break;
                    case "z":
                        ProcesszRecord(record);
                        break;
                    case "e":
                        ProcesseRecord(record);
                        break;
                    default:
                        Console.WriteLine("Unknown record type: " + record[0]);
                        break;
                }
            }
        }

        static void ProcessPRecord(string[] record)
        {
            Console.WriteLine("Processing P record:");
            Console.WriteLine($"- Field 1: {record[1]}");
            Console.WriteLine($"- Field 2: {record[2]}");
            Console.WriteLine($"- Field 3: {record[3]}");
            Console.WriteLine($"- UUID: {record[4]}");
            // Process other fields if necessary
        }

        static void ProcessXRecord(string[] record)
        {
            Console.WriteLine("Processing X record:");
            Console.WriteLine($"- Field 1: {record[1]}");
            Console.WriteLine($"- Field 2: {record[2]}");
            Console.WriteLine($"- Field 3: {record[3]}");
            Console.WriteLine($"- Field 4: {record[4]}");
            // Process other fields if necessary
        }

        static void ProcessSRecord(string[] record)
        {
            Console.WriteLine("Processing S record:");
            Console.WriteLine($"- Subtype: {record[1]}");
            Console.WriteLine($"- Field 2: {record[2]}");
            Console.WriteLine($"- Field 3: {record[3]}");
            Console.WriteLine($"- Field 4: {record[4]}");
            // Process other fields if necessary
        }

        static void ProcesspRecord(string[] record)
        {
            Console.WriteLine("Processing p record:");
            Console.WriteLine($"- Field 1: {record[1]}");
            Console.WriteLine($"- Field 2: {record[2]}");
            Console.WriteLine($"- Field 3: {record[3]}");
            Console.WriteLine($"- Field 4: {record[4]}");
            Console.WriteLine($"- UUID: {record[6]}");
            // Process other fields if necessary
        }

        static void ProcesszRecord(string[] record)
        {
            Console.WriteLine("Processing z record:");
            Console.WriteLine($"- Field 1: {record[1]}");
            Console.WriteLine($"- Field 2: {record[2]}");
            // Process other fields if necessary
        }

        static void ProcesseRecord(string[] record)
        {
            Console.WriteLine("Processing e record:");
            Console.WriteLine($"- Field 1: {record[1]}");
            Console.WriteLine($"- Field 2: {record[2]}");
            // Process other fields if necessary
        } */
    }
}
