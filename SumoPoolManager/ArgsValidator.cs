using System.Text.Json;

namespace SumoPoolManager
{
    /// <summary>
    /// Service class to do the all the validation of the inputs
    /// </summary>
    public static class ArgsValidator
    {
        public static string MessageErreurParam1() => "Le premier paramètre doit être un chemin valide vers un fichier .json dans le format attendu";
        public static string MessageErreurParam2() => "Le deuxième paramètre doit être un chiffre entre 1 et 15";
        public static string PasDeuxArguments() => "Il doit y avoir 2 argument, un chemin valide vers un fichier .json et un chiffre entre 1 et 15";

        /// <summary>
        ///  Performs several validations on the input arguments and returns a list of error messages in the ValidationResult object if any of the validations fail.
        /// </summary>
        /// <param name="args">The parameters passed to the programs as an array of string</param>
        /// <returns>A list of error messages in the ValidationResult object if any of the validations fail.</returns>
        public static ValidationResult Validate(string[] args)
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

            //tries to deserialize the JSON file into a Pool object and checks if the Participants list is not empty and if the TimestampId property is not null or empty.
            //If it fails any of these checks, it returns an error message.
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
