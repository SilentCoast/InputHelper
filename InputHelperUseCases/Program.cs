using InputHelper;

namespace InputHelperUseCases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UserInputController.GetDoubleInput("Enter double: ");
            }
            Console.ReadKey();  
        }
    }
}
