namespace SumoPoolManager
{
    public class Participant
    {
        public string Name { get; set; }
        public short Score { get; set; }
        public List<Rikishi> Rikishis { get; set; } = new();
    }
}
