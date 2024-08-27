using Tgs.GameRecord.GKXGaming.Core.JobApplicationServices;

namespace Tgs.GameRecord.GKXGaming.Core;

public interface IHangfireUtensilRepository
{
	public Task JobCheckAsync();

	public Task JobExecuteAsync(JobExecuteCommand source);

	public Task JobInitAsync();
}
