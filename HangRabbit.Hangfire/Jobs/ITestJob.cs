using Hangfire;
using Hangfire.Server;
using HangRabbit.Models;

namespace HangRabbit.Hangfire.Jobs
{
    public interface ITestJob
    {
        [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        Task DoThings(TestEvent testEvent, CancellationToken cancellationToken, PerformContext? contexto = null);
    }
}
