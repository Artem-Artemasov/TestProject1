using System;
using Kata1;

namespace TestProject.Kata1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            string input;
            StringCalculator calculator = new StringCalculator();

            Console.Write("Enter comma separated numbers (enter to exit):\n\t> ");

            while(running)
            {
                input = Console.ReadLine();
                if(string.IsNullOrEmpty(input))
                {
                    running = false;
                    continue;
                }
                try
                {
                    Console.WriteLine($"Result is: {calculator.Add(input)}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}\n\n");
                }
                Console.Write("Enter comma separated numbers (enter to exit):\n\t> ");
            }
        }
    }
}
