using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.GKXGaming.Core.ApplicationServices;
using Tgs.GameRecord.GKXGaming.ViewModels;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.GKXGaming.Controllers;

[ApiController]
[Route("GKX")]
public class GKXGamingController : ControllerBase
{
    /// <summary>
    /// Games the record asynchronous.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    /// <remarks>
    /// <b>Example</b><br />
    ///
    ///     Post
    ///         {
    ///             "apiRecordUrl": "https://wc-record.orz16.com/",
    ///             "deskey": "03CFE0179704BCDF",
    ///             "md5key": "337B01054C6FA208",
    ///             "agentId": "60073",
    ///             "startTime": "2023-07-26T11:50:00+08:00",
    ///             "endTime": "2023-07-26T12:00:00+08:00"
    ///         }
    /// </remarks>
    [HttpPost]
    public ValueTask GameRecordAsync(
        [FromServices] ICommandService<PullRecordCommand> service,
        PullRecordViewModel source)
    {
        var command = new PullRecordCommand(
            ApiUrl: source.ApiRecordUrl,
            Deskey: source.Deskey,
            Md5key: source.Md5key,
            AgentId: source.AgentId,
            StartTime: source.StartTime,
            EndTime: source.EndTime);
        return service
            .ExecuteAsync(
            command,
            HttpContext.RequestAborted);
    }
}
