using Hangfire.Dashboard;

namespace Tgs.GameRecord.GKXGaming;

public class IgnoreHangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}
