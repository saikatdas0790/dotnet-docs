using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.ReadKey(true);

            Console.WriteLine("\nWhat is your name? ");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
