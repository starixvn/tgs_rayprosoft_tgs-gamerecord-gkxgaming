using Tgs.GameRecord.GKXGaming.Core.JobApplicationServices;

namespace Tgs.GameRecord.GKXGaming.Core;

public interface IHangfireUtensil
{
	public Task JobCheckAsync();

	public Task JobExecuteAsync(JobExecuteCommand source);

	public Task JobInitAsync();
}
