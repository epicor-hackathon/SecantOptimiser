using Microsoft.Extensions.FileSystemGlobbing.Internal;
using SecantOptimiserAPI.Models.Request;
using System.Runtime.ConstrainedExecution;

namespace SecantOptimiserAPI.Services
{
    public class ControlService : IControlService
    {
        public string[] GetLines(RequestModel requestModel)
        {
            List<string> lines =
                [
                "{sections}"
                //,"#45001=;1,-1,40001"
                //,"{#45001}"
                ,"#33001=1;1,-1,33001" // this tells the system you are doing bar (1D) cutting
                ,$"#33002=s;1,-1,33002" // this tells the system you have a single material in the cutting list
                //,"#33007=Metric;1,-1,33007" // this tells the system your units are Metric
                ,"#33072=Normal;1,-1,33072" // use speed Normal
                ,$"#33019={requestModel.cuttingOptions.sawTolerance};1,-1,33019" // kerf value
                ,$"#33083={requestModel.cuttingOptions.minimumOffcutLengthToStock};1,-1,33083" // minimum offcut in mm
                ,"#33247=0;1,-1,33247"
                //,$"#33144={requestModel.cuttingOptions.clampWidth};1,-1,33144" // Mitre clamp width
                //,$"#33062={requestModel.cuttingOptions.maximumDifferentCutLengths};1,-1,33062" // Maximum cross cut length . 33051, 33052
                //,$"#33030={requestModel.cuttingOptions.maximumDifferentCutLengths};1,-1,33030" // Maximum strip length
                // 33045 : Max physical pieces per strip
                // 33048 Max physical pieces per patterns
                //,$"#33049={requestModel.cuttingOptions.maximumPiecesEx1Bar};1,-1,33049" // Max piece identifiers per pattern
                //,$"#33026={requestModel.cuttingOptions.leftFrontTrim};1,-1,33026" // Trim strip frontss
                //,$"#33027={requestModel.cuttingOptions.rightBackTrim};1,-1,33027" // Trim strip back
                //
                ];
            return lines.ToArray();
        }
    }
}
