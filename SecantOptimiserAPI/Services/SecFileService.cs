using SecantOptimiserAPI.Models;
using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SecantOptimiserAPI.Services;
public class SecFileService : ISecFileService
{
    readonly ICuttingDataService _cuttingDataRequestService;
    readonly IStockDataService _stockDataRequestService;
    readonly IJobDataRequestService _jobDataRequestService;
    readonly IControlService _controlService;
    readonly IPatternService _patternService;
    public SecFileService(ICuttingDataService cuttingDataRequestService,
                          IStockDataService stockDataRequestService,
                          IJobDataRequestService jobDataRequestService,
                          IPatternService patternService,
                          IControlService controlService)
    {
        _cuttingDataRequestService = cuttingDataRequestService;
        _stockDataRequestService = stockDataRequestService;
        _jobDataRequestService = jobDataRequestService;
        _patternService = patternService;
        _controlService = controlService;
    }
    public OptimiserResponse ReadFromFile(RequestModel inputModel, string path)
    {
        return GetOptimiserResponse(inputModel, path);
    }

    public void ToSecFile(RequestModel inputModel,string path)
    {
        List<SecantSection> sections = new();
        AddLinesToSection(UtilityService.SEC_NAME_JOB, _jobDataRequestService.GetLines(inputModel),ref sections);
        AddLinesToSection(UtilityService.SEC_NAME_CUT, _cuttingDataRequestService.GetLines(inputModel),ref sections);
        AddLinesToSection(UtilityService.SEC_NAME_STK, _stockDataRequestService.GetLines(inputModel),ref sections);
        AddLinesToSection(UtilityService.SEC_NAME_CTL, _controlService.GetLines(inputModel),ref sections);
        WriteToFile(path, sections);
    }

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

    private OptimiserResponse GetOptimiserResponse(RequestModel inputModel, string path)
    {
        OptimiserResponse? optimiserResponse = null;
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
                    sections.Add(ReadSection(sectionLines.ToArray()));
                    sectionLines = new List<string>();
                }
            }
            sectionLines.Add(line);
        }
        if (sectionLines.Count > 0)
        {
            sections.Add(ReadSection(sectionLines.ToArray()));
        }
        SecantSection? cutSection = sections.FirstOrDefault(s => s.Name.Equals(UtilityService.SEC_NAME_OVM));
        optimiserResponse = _cuttingDataRequestService.BuildCuttingData(inputModel, cutSection);

        SecantSection? stkSection = sections.FirstOrDefault(s => s.Name.Equals(UtilityService.SEC_NAME_USD));
        _stockDataRequestService.BuildStockData(inputModel, stkSection, ref optimiserResponse);

        SecantSection? patSection = sections.FirstOrDefault(s => s.Name.Equals(UtilityService.SEC_NAME_PAT));
        _patternService.BuildPatternData(inputModel, patSection, ref optimiserResponse);
        return optimiserResponse;
    }

    void AddLinesToSection(string sectionName, string[] lines,ref List<SecantSection> sections)
    {
        var section = sections.FirstOrDefault(s => s.Name == sectionName);
        if (section == null)
        {
            section = new SecantSection { Name = sectionName, Lines = new List<string>() };
            sections.Add(section);
        }
        section.Lines.AddRange(lines.ToArray());
    }
    void WriteToFile(string path, List<SecantSection> sections)
    {
        using var writer = new StreamWriter(path);
        foreach (var section in sections)
        {
            WriteSection(section, writer);
        }
    }

    void WriteSection(SecantSection section, StreamWriter writer)
    {
        writer.WriteLine($"[{section.Name}]");
        foreach (var line in section.Lines)
        {
            writer.WriteLine(line);
        }
    }


}

