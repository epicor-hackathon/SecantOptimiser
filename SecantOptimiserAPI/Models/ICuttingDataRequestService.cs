﻿namespace SecantOptimiserAPI.Models
{
    public interface ICuttingDataRequestService
    {
        string[] GetLines(RequestModel requestModel);
    }
}
