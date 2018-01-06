using System;
using System.Collections.Generic;

namespace FibonacciNumberGenerator
{
    class Program
    {
        public static void Main(string[] args)
        {
            foreach (var item in GenerateFibonacciList(20))
            {
                Console.WriteLine(item);
            }
        }

        static List<int> GenerateFibonacciList(int size)
        {
            var listOfNumbers = new List<int>() { 1, 1 };

            for (int i = 2; i < size; i++)
                listOfNumbers.Add(listOfNumbers[i - 2] + listOfNumbers[i - 1]);

            return listOfNumbers;
        }
    }
}
