using System;
using System.Diagnostics.CodeAnalysis;

namespace GUI_05
{
    internal class Program
    {
        public static void Sum()
        {
            int sum = 0;
            int sumLimit = 150;
            int num;
            int even = 0, odd = 0;

            do
            {
                bool isNumber;
                do
                {
                    Console.Write("num = ");
                    String input = Console.ReadLine();
                    isNumber = int.TryParse(input, out num);
                    if (!isNumber) Console.WriteLine("Input is not numerical. Please enter it again.");
                } while (!isNumber);

                sum += num;
                if (num % 2 == 0) even++;
                else odd++;

            } while (sum < sumLimit);
            
            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Even numbers count: " + even);
            Console.WriteLine("Odd numbers count: " + odd);
        }
        
        public static void Main(string[] args)
        {
            Sum();
        }
    }
}