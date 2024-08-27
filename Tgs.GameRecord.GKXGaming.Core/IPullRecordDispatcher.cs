using Tgs.GameRecord.GKXGaming.Core.ApplicationServices;

namespace Tgs.GameRecord.GKXGaming.Core;

public interface IPullRecordDispatcher
{
	ValueTask PushCommandAsync(PullRecordCommand command, CancellationToken cancellationToken = default);
}
