﻿namespace SumoPoolManager.Models
{
    public record WinnerOnDay
    {
        public string Name { get; set; } = string.Empty;
        public short Day { get; set; }
    }
}