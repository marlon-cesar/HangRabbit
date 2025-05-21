using Hangfire.Console;
using Hangfire.Server;
using HangRabbit.Models;

namespace HangRabbit.Hangfire.Jobs
{
    public class TestJob : ITestJob
    {
        public async Task DoThings(TestEvent testEvent, CancellationToken cancellationToken, PerformContext? contexto = null)
        {
            contexto?.WriteLine(testEvent.ToString());
        }
    }
}
