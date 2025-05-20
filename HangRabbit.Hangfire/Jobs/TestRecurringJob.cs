using Hangfire.Console;
using Hangfire.Server;

namespace HangRabbit.Hangfire.Jobs
{
    public class TestRecurringJob : ITestRecurringJob
    {
        public async Task DoRecurringThing(CancellationToken cancellationToken, PerformContext? contexto = null)
        {
            var progress = contexto?.WriteProgressBar(color: ConsoleTextColor.Green);

            progress?.SetValue(0);
            contexto?.WriteLine("Initializing job...");

            await Task.Delay(3000);

            progress?.SetValue(50);
            contexto?.WriteLine("Doing things...");

            await Task.Delay(5000);

            contexto?.WriteLine("Finished...");
            progress?.SetValue(100);
        }

    }
}
