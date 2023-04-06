namespace SumoPoolManager
{
    public class Pool
    {
        public string TimestampId { get; set; }
        public List<Participant> Participants { get; set; } = new();
    }
}
