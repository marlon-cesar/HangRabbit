using Hangfire;
using Hangfire.Server;

namespace HangRabbit.Hangfire.Jobs
{
    public interface ITestRecurringJob
    {
        [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        Task DoRecurringThing(CancellationToken cancellationToken, PerformContext? contexto = null);
    }
}
