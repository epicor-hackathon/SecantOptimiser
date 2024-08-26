using System.Text.RegularExpressions;

namespace SecantOptimiserAPI.Models
{
    public class SecantSection
    {
        public string Name { get; set; }
        public List<string> Lines { get; set; }

        public virtual void WriteSection(StreamWriter writer)
        {
            writer.WriteLine($"[{Name}]");
            foreach (var line in Lines)
            {
                writer.WriteLine(line);
            }
        }

        public static T ReadSection<T>(string[] lines) where T : SecantSection, new()
        {
            if (!lines.Any())
            {
                throw new Exception("No lines to read");
            }
            var section = new T();
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
