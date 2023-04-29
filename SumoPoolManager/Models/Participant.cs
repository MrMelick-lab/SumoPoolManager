namespace SumoPoolManager.Models
{
    public class Participant
    {
        public string Name { get; set; } = string.Empty;
        public short Score { get; set; }
        public List<Rikishi> Rikishis { get; set; } = new();
    }
}
