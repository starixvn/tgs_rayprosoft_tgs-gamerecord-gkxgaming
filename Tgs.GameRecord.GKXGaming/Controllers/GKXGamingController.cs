using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameRecord.GKXGaming.Common;
using Valhalla.MessageQueue;

namespace Tgs.GameRecord.GKXGaming.Controllers;

[ApiController]
[Route("GKX")]
public class GKXGamingController : ControllerBase
{
	/// <summary>
	/// Games the record manual asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///         {
	///             "apiUrl": "https://wc-record.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "md5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "startTime": "2023-07-26T11:50:00+08:00",
	///             "endTime": "2023-07-26T12:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("manual")]
	public ValueTask GameRecordManualAsync(
		[FromServices] IMessageSender messageSender,
		GKXGamingGameRecordMessage source)
		=> messageSender.PublishAsync(
			subject: GKXGamingNatsConst.ManualPublish,
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(source)),
			cancellationToken: HttpContext.RequestAborted);

	/// <summary>
	/// Games the record schedule asynchronous.
	/// </summary>
	/// <param name="messageSender">The message sender.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///         {
	///             "apiUrl": "https://wc-record.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "md5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "startTime": "2023-07-26T11:50:00+08:00",
	///             "endTime": "2023-07-26T12:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("schedule")]
	public ValueTask GameRecordScheduleAsync(
		[FromServices] IMessageSender messageSender,
		GKXGamingGameRecordMessage source)
		=> messageSender.PublishAsync(
			subject: GKXGamingNatsConst.SchedulePublish,
			data: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(source)),
			cancellationToken: HttpContext.RequestAborted);
}
