namespace InputHelper
{
    public static class UserInputController
    {
        private static T GetPositiveInput<T>(string message, string errorMessage, Func<string, (bool, T)> parser)
        {
            T result;
            bool parsingSuccess;
            do
            {
                Console.Write(message);
                var input = Console.ReadLine();
                (parsingSuccess, result) = parser(input);
                if (!parsingSuccess || Comparer<T>.Default.Compare(result, default(T)) <= 0)
                {
                    Console.WriteLine(errorMessage);
                }
            } while (!parsingSuccess || Comparer<T>.Default.Compare(result, default(T)) <= 0);

            return result;
        }

        public static int GetPositiveIntegerInput(string message, string errorMessage = "Wrong input")
        {
            return GetPositiveInput(message, errorMessage, input =>
            {
                bool success = int.TryParse(input, out int value);
                return (success, value);
            });
        }

        public static decimal GetPositiveDecimalInput(string message, string errorMessage = "Wrong input")
        {
            return GetPositiveInput(message, errorMessage, input =>
            {
                decimal value;
                bool success = decimal.TryParse(input, out value);
                return (success, value);
            });
        }

        public static double GetPositiveDoubleInput(string message, string errorMessage = "Wrong input")
        {
            return GetPositiveInput(message, errorMessage, input =>
            {
                double value;
                bool success = double.TryParse(input, out value);
                return (success, value);
            });
        }
        private static T GetInput<T>(string message, string errorMessage, Func<string, (bool, T)> parser)
        {
            T result;
            bool parsingSuccess;
            do
            {
                Console.Write(message);
                var input = Console.ReadLine();
                (parsingSuccess, result) = parser(input);
                if (!parsingSuccess)
                {
                    Console.WriteLine(errorMessage);
                }
            } while (!parsingSuccess);

            return result;
        }
        public static double GetDoubleInput(string message, string errorMessage = "Wrong input")
        {
            return GetInput(message, errorMessage, input =>
            {
                double value;
                bool success = double.TryParse(input, out value);
                return (success, value);
            });
        }
        public static string GetStringInput(string message, string errorMessage = "Wrong input")
        {
            return GetInput(message, errorMessage, input =>
            {
                bool success = !string.IsNullOrEmpty(input);
                return (success, input);
            });
        }
    }
}
