namespace InputHelper
{
    public static class UserInputController
    {
        public static T GetPositiveInput<T>(string message, string errorMessage, Func<string, (bool, T)> parser)
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

        public static int GetPositiveIntegerInput(string message, string errorMessage)
        {
            return GetPositiveInput(message, errorMessage, input =>
            {
                bool success = int.TryParse(input, out int value);
                return (success, value);
            });
        }

        public static decimal GetPositiveDecimalInput(string message, string errorMessage)
        {
            return GetPositiveInput(message, errorMessage, input =>
            {
                decimal value;
                bool success = decimal.TryParse(input, out value);
                return (success, value);
            });
        }

        public static double GetPositiveDoubleInput(string message, string errorMessage)
        {
            return GetPositiveInput(message, errorMessage, input =>
            {
                double value;
                bool success = double.TryParse(input, out value);
                return (success, value);
            });
        }
        public static string GetStringInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
