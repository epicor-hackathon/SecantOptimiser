using SecantOptimiserAPI.Models;
using SecantOptimiserAPI.Models.Request;
using System.Text.RegularExpressions;

namespace SecantOptimiserAPI.Services
{
    public class SecantSectionService : ISecantSection
    {
        public SecantSection ReadSection(string[] lines)
        {
            if (!lines.Any())
            {
                throw new Exception("No lines to read");
            }
            SecantSection section = new();
            var header = lines[0];
            var headerMatch = Regex.Match(header, @"\s*\[(.*)\]\s*", RegexOptions.IgnoreCase);

            if (!headerMatch.Success || headerMatch.Groups.Count < 2)
            {
                throw new Exception("Invalid section header");
            }
            section.Name = headerMatch.Groups[^1].Value;
            section.Lines = new List<string>(lines.Skip(1));

            return section;
        }
    }
}
