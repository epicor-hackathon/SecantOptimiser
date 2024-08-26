using SecantOptimiserAPI.Models;

namespace SecantOptimiserAPI.Services;
public class SecFileService : ISecFileService
{
    readonly ISecantSection _secantSectionService;
    readonly ICuttingDataRequestService _cuttingDataRequestService;
    readonly IStockDataRequestService _stockDataRequestService;
    public SecFileService(ICuttingDataRequestService cuttingDataRequestService, IStockDataRequestService stockDataRequestService, ISecantSection secantSectionService)
    {
        _secantSectionService = secantSectionService;
        _cuttingDataRequestService = cuttingDataRequestService;
        _stockDataRequestService = stockDataRequestService;
    }
    public void ReadFromFile(string path)
    {
        var lines = File.ReadAllLines(path);
        var sections = new List<SecantSectionService>();

        // split lines into sections each starting with section header
        var sectionLines = new List<string>();
        foreach (var line in lines)
        {
            if (line.Trim().StartsWith("["))
            {
                if (sectionLines.Count > 0)
                {
                    sections.Add(_secantSectionService.ReadSection(sectionLines.ToArray()));
                    sectionLines = new List<string>();
                }
            }
            sectionLines.Add(line);
        }
        if (sectionLines.Count > 0)
        {
            sections.Add(_secantSectionService.ReadSection(sectionLines.ToArray()));
        }
        this.Sections = sections;
    }

    public void ToSecFile(RequestModel inputModel,string path)
    {
        AddLinesToSection(UtilityService.SEC_NAME_CUT, _cuttingDataRequestService.GetLines(inputModel));
        AddLinesToSection(UtilityService.SEC_NAME_STK, _stockDataRequestService.GetLines(inputModel));
        WriteToFile(path);
    }

    public void WriteToFile(string path)
    {
        using var writer = new StreamWriter(path);
        foreach (var section in Sections)
        {
            _secantSectionService.WriteSection(section,writer);
        }
    }

    public void AddLinesToSection(string sectionName, string[] lines)
    {
        var section = Sections.FirstOrDefault(s => s.Name == sectionName);
        if (section == null)
        {
            section = new SecantSectionService { Name = sectionName, Lines = new List<string>() };
            Sections.Add(section);
        }
        section.Lines.AddRange(lines.ToArray());
    }



    public List<SecantSectionService> Sections { get; set; } = new();

}

