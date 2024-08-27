using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.GKXGaming.Common;

public record GKXGamingGameRecordMessage
{
	[Required]
	[DataType(DataType.Url)]
	[DefaultValue(typeof(Uri), "https://wc-record.orz16.com/")]
	public Uri ApiUrl { get; init; } = default!;

	[Required]
	[DefaultValue(typeof(string), "03CFE0179704BCDF")]
	public string Deskey { get; init; } = default!;

	[Required]
	[DefaultValue(typeof(string), "337B01054C6FA208")]
	public string Md5key { get; init; } = default!;

	[Required]
	[DefaultValue(typeof(string), "60073")]
	public string AgentId { get; init; } = default!;

	[Required]
	[DataType(DataType.DateTime)]
	[DefaultValue(typeof(DateTimeOffset), "2023-07-26T11:50:00+08:00")]
	public DateTimeOffset StartTime { get; init; } = default!;

	[Required]
	[DataType(DataType.DateTime)]
	[DefaultValue(typeof(DateTimeOffset), "2023-07-26T12:00:00+08:00")]
	public DateTimeOffset EndTime { get; init; } = default!;
}
