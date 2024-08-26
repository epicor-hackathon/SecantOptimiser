using SecantOptimiserAPI.Models;
using SecantOptimiserAPI.Models.Request;
using SecantOptimiserAPI.Models.Response;
using System.Collections.Generic;

namespace SecantOptimiserAPI.Services;
public class SecFileService : ISecFileService
{
    readonly ISecantSection _secantSectionService;
    readonly ICuttingDataRequestService _cuttingDataRequestService;
    readonly IStockDataRequestService _stockDataRequestService;
    readonly IJobDataRequestService _jobDataRequestService;
    readonly IOptimiserResponseService _optimiserResponseService;
    public SecFileService(ICuttingDataRequestService cuttingDataRequestService, IStockDataRequestService stockDataRequestService, ISecantSection secantSectionService, IJobDataRequestService jobDataRequestService,
        IOptimiserResponseService optimiserResponseService)
    {
        _secantSectionService = secantSectionService;
        _cuttingDataRequestService = cuttingDataRequestService;
        _stockDataRequestService = stockDataRequestService;
        _jobDataRequestService = jobDataRequestService;
        _optimiserResponseService = optimiserResponseService;   
    }
    public OptimiserResponse ReadFromFile(string path)
    {
        return _optimiserResponseService.GetOptimiserResponse(path);
    }

    public void ToSecFile(RequestModel inputModel,string path)
    {
        List<SecantSection> sections = new();
        AddLinesToSection(UtilityService.SEC_NAME_JOB, _jobDataRequestService.GetLines(inputModel),ref sections);
        AddLinesToSection(UtilityService.SEC_NAME_CUT, _cuttingDataRequestService.GetLines(inputModel),ref sections);
        AddLinesToSection(UtilityService.SEC_NAME_STK, _stockDataRequestService.GetLines(inputModel),ref sections);
        WriteToFile(path, sections);
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

