using SecantOptimiserAPI.Models;
using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SecantOptimiserAPI.Services;
public class SecFileService : ISecFileService
{
    readonly ICuttingDataRequestService _cuttingDataRequestService;
    readonly IStockDataRequestService _stockDataRequestService;
    readonly IJobDataRequestService _jobDataRequestService;

    public SecFileService(ICuttingDataRequestService cuttingDataRequestService, IStockDataRequestService stockDataRequestService, IJobDataRequestService jobDataRequestService)
    {
        _cuttingDataRequestService = cuttingDataRequestService;
        _stockDataRequestService = stockDataRequestService;
        _jobDataRequestService = jobDataRequestService;
    }
    public OptimiserResponse ReadFromFile(string path)
    {
        return GetOptimiserResponse(path);
    }

    public void ToSecFile(RequestModel inputModel,string path)
    {
        List<SecantSection> sections = new();
        AddLinesToSection(UtilityService.SEC_NAME_JOB, _jobDataRequestService.GetLines(inputModel),ref sections);
        AddLinesToSection(UtilityService.SEC_NAME_CUT, _cuttingDataRequestService.GetLines(inputModel),ref sections);
        AddLinesToSection(UtilityService.SEC_NAME_STK, _stockDataRequestService.GetLines(inputModel),ref sections);
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

    private OptimiserResponse GetOptimiserResponse(string path)
    {
        OptimiserResponse optimiserResponse = new OptimiserResponse();
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
        foreach (var item in sections)
        {
            //switch (item.Name)
            //{
            //    case UtilityService.SEC_NAME_JOB:
            //         _jobDataService.GetOptimiserResponse(item);
            //        break;
            //    case UtilityService.SEC_NAME_CUT:
            //        _cuttingDataService.GetOptimiserResponse(optimiserResponse, item);
            //        break;
            //    case UtilityService.SEC_NAME_STK:
            //        _stockDataService.GetOptimiserResponse(item);
            //        break;
            //}
        }
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

