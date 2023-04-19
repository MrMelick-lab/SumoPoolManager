using System.Text.Json;

namespace SumoPoolManager
{
    public class ArgsValidator
    {
        public static string MessageErreurParam1() => "Le premier paramètre doit être un chemin valide vers un fichier .json dans le format attendu";
        public static string MessageErreurParam2() => "Le deuxième paramètre doit être un chiffre entre 1 et 15";
        public static string PasDeuxArguments() => "Il doit y avoir 2 argument, un chemin valide vers un fichier .json et un chiffre entre 1 et 15";

        public ValidationResult Validate(string[] args)
        {
            var result = new ValidationResult();

            if (args.Length != 2)
            {
                result.Messages.Add(PasDeuxArguments());
                return result;
            }

            if (string.IsNullOrEmpty(args[0]))
            {
                result.Messages.Add(MessageErreurParam1());
                return result;
            }

            if (!File.Exists(args[0]))
            {
                result.Messages.Add(MessageErreurParam1());
                return result;
            }

            if (Path.GetExtension(args[0]) != ".json")
            {
                result.Messages.Add(MessageErreurParam1());
                return result;
            }

            try
            {
                using var poolStream = File.OpenRead(args[0]);
                var pool = JsonSerializer.Deserialize<Pool>(poolStream);
                if (pool?.Participants.Any() == false || string.IsNullOrEmpty(pool?.TimestampId))
                {
                    result.Messages.Add(MessageErreurParam1());
                    return result;
                }
            }
            catch (JsonException)
            {
                result.Messages.Add(MessageErreurParam1());
                return result;
            }
            catch (NotSupportedException)
            {
                result.Messages.Add(MessageErreurParam1());
                return result;
            }

            if (string.IsNullOrWhiteSpace(args[1]) || !short.TryParse(args[1], out var param2) || param2 < 1 || param2 > 15)
                result.Messages.Add(MessageErreurParam2());

            return result;
        }
    }
}
