namespace SumoPoolManager
{
    public record BoutResult
    {
        public string Name { get; set; } = string.Empty;
        public short Day { get; set; }
        public bool Win { get; set; }
    }
}