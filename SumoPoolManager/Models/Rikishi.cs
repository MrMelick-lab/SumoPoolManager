﻿namespace SumoPoolManager.Models
{
    public class Rikishi
    {
        public string Name { get; set; } = string.Empty;
        public short DayOfEntry { get; set; }
        public short Score { get; set; }

        public string NameAndScore => $"{Name} {Score}";
    }
}
