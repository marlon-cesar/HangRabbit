namespace HangRabbit.Models
{
    public class TestEvent
    {
        public Guid EventId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public string ToString() =>
            $"EventId: {EventId}, Description: {Description}, CreatedAt: {CreatedAt}";
    }
}
