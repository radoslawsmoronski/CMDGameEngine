using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDGameEngine.Additional
{
    public static class ConsoleMessages
    {
        public static bool Confirmation(string question)
        {
            Console.WriteLine(question);
            Console.WriteLine("Write 'yes' to accept, or 'no' to decline.");

            string input = Console.ReadLine()?.Trim().ToLowerInvariant();

            while (input != "yes" && input != "no")
            {
                Console.WriteLine("Please write 'yes' or 'no'.");
                input = Console.ReadLine()?.Trim().ToLowerInvariant();
            }

            return input == "yes";
        }

        public static void Error(string message)
        {
            Console.WriteLine("Error: " + message);
            Console.ReadKey();
        }
    }
}
