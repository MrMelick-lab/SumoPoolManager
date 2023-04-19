namespace SumoPoolManager
{
    public class ValidationResult
    {
        public bool IsValid() => Messages.Count == 0;
        public List<string> Messages { get; set; } = new();
    }
}
