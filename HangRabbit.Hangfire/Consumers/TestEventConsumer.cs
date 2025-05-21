using Hangfire;
using HangRabbit.Hangfire.Jobs;
using HangRabbit.Models;
using MassTransit;

namespace HangRabbit.Hangfire.Consumers
{

    public class TestEventConsumer : IConsumer<TestEvent>
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public TestEventConsumer(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public Task Consume(ConsumeContext<TestEvent> context)
        {
            _backgroundJobClient.Enqueue<ITestJob>(x => x.DoThings(context.Message, context.CancellationToken, null));

            return Task.CompletedTask;
        }
    }
}
