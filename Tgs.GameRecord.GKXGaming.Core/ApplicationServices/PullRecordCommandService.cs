using Microsoft.Extensions.Logging;
using Tgs.GameInterface.GKXGaming.Client;
using Tgs.GameInterface.GKXGaming.Protos;
using Tgs.ServiceUtility;

namespace Tgs.GameRecord.GKXGaming.Core.ApplicationServices;

internal class PullRecordCommandService : ICommandService<PullRecordCommand>
{
    private readonly IGameInterfaceGKXGamingClient _client;
    private readonly ILogger<PullRecordCommandService> _logger;
    private readonly ICommandService<HandleRecordCommand> _service;

    public PullRecordCommandService(
        ILogger<PullRecordCommandService> logger,
        IGameInterfaceGKXGamingClient client,
        ICommandService<HandleRecordCommand> service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async ValueTask ExecuteAsync(PullRecordCommand command, CancellationToken cancellationToken = default)
    {
        var gameRecords = await _client
            .GameRecordAsync(
            apiUrl: command.ApiUrl,
            deskey: command.Deskey,
            md5key: command.Md5key,
            agentId: command.AgentId,
            startTime: command.StartTime,
            endTime: command.EndTime,
            cancellationToken: cancellationToken)
            .ToArrayAsync(
            cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<GameRecordInfo>();

        foreach (var gameRecord in gameRecords)
        {
            try
            {
                await _service
                .ExecuteAsync(
                     command: new HandleRecordCommand(gameRecord),
                     cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LogOn:{logOn} Message: An exception occurred in this game record.({gameRecord})", DateTime.Now.ToString("o"), gameRecord);
            }
        }
    }
}
