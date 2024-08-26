namespace SecantOptimiserAPI.Models;
public class SecFile
{
    public static SecFile ReadFromFile(string path)
    {
        var file = new SecFile();
        var lines = File.ReadAllLines(path);
        var sections = new List<SecantSection>();

        // split lines into sections each starting with section header
        var sectionLines = new List<string>();
        foreach (var line in lines)
        {
            if (line.Trim().StartsWith("["))
            {
                if (sectionLines.Count > 0)
                {
                    sections.Add(SecantSection.ReadSection<SecantSection>(sectionLines.ToArray()));
                    sectionLines = new List<string>();
                }
            }
            sectionLines.Add(line);
        }
        if (sectionLines.Count > 0)
        {
            sections.Add(SecantSection.ReadSection<SecantSection>(sectionLines.ToArray()));
        }
        file.Sections = sections;
        return file;
    }

    public void WriteToFile(string path)
    {
        using var writer = new StreamWriter(path);
        foreach (var section in Sections)
        {
            section.WriteSection(writer);
        }
    }

    public void AddLinesToSection(string sectionName, string[] lines)
    {
        var section = Sections.FirstOrDefault(s => s.Name == sectionName);
        if (section == null)
        {
            section = new SecantSection { Name = sectionName, Lines = new List<string>() };
            Sections.Add(section);
        }
        section.Lines.AddRange(lines.ToArray());
    }

    public List<SecantSection> Sections { get; set; } = new();

}

