using CsvHelper.Configuration.Attributes;

namespace SumoPoolManager.Models
{
    public class CsvRecords
    {
        [Index(0)]
        public string Timestamp { get; set; }
        [Index(1)]
        public string Username { get; set; }
        [Index(2)]
        public string PseudoTwitch { get; set; }
        [Index(3)]
        public string YokozunaOzeki { get; set; }
        [Index(4)]
        public string Sekiwake { get; set; }
        [Index(5)]
        public string KomusubiAndMaegashira1 { get; set; }
        [Index(6)]
        public string Maegashira2To4 { get; set; }
        [Index(7)]
        public string Maegashira5To7 { get; set; }
        [Index(8)]
        public string Maegashira8To11 { get; set; }
        [Index(9)]
        public string Maegashira12To17 { get; set; }
        [Index(10)]
        public string RikishiReplacement1 { get; set; }
        [Index(11)]
        public string RikishiReplacement2 { get; set; }
    }
}
