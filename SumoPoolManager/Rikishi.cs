namespace SumoPoolManager
{
    public class Rikishi
    {
        public string Name { get; set; }
        public short DayOEntry { get; set; } = 0;
        public short DayOfExit { get; set; } = 0;
        public bool IsOut { get; set; } = false;
    }
}
