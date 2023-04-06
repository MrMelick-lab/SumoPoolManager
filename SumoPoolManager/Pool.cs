namespace SumoPoolManager
{
    public class Pool
    {
        public string TimestampId { get; set; } = string.Empty;
        public List<Participant> Participants { get; set; } = new();
    }
}
