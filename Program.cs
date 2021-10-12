using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;

namespace GUI_05
{
    internal class Program
    {
        public static int SumRange()
        {
            int sum = 0;
            int num;
            
            bool isNumber;
            do
            {
                Console.Write("num = ");
                String input = Console.ReadLine();
                isNumber = int.TryParse(input, out num);
                if (!isNumber) Console.WriteLine("Input is not numerical. Please enter it again.");
            } while (!isNumber);

            for (int i = 1; i <= num; i++)
            {
                sum += i;
            }

            return sum;
        }

        public static void MultiplicationTable()
        {
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    Console.Write(i*j + " ");
                }
                Console.WriteLine();
            }

        }

        public static void MinMax3Num()
        {
            int a, b, c;
            Console.WriteLine("Please enter 3 numbers:");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = Convert.ToInt32(Console.ReadLine());

            int min, max;

            min = Math.Min(Math.Min(a, b), c);
            max = Math.Max(Math.Max(a, b), c);
            
            Console.WriteLine("min = " + min);
            Console.WriteLine("max = " + max);
        }
        
        public static void Sum150()
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

        public static void PrintArray(int[] a)
        {
            foreach(var i in a)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
        }

        public static int BubbleSort(int[] array)
        {
            int switchCount = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length - 1; j++)
                {
                    switchCount++;
                    
                    if (array[i] > array[j])
                        (array[i], array[j]) = (array[j], array[i]);
                    
                }
            }
            
            PrintArray(array);

            return switchCount;
        }

        public static int RandomSort(int[] array)
        {
            int switchCount = 0;
            do
            {
                Random rnd = new Random();
                int[] MyRandomArray = array.OrderBy(x => rnd.Next()).ToArray();
                array = MyRandomArray;
                switchCount++;
                if (switchCount % 100000 == 0) Console.WriteLine("Shuffles so far: " + switchCount);
            } while (!isSorted(array));
            
            PrintArray(array);

            return switchCount;
        }
        
        public static int SolarBitflipSort(int[] array)
        {
            do
            {
                Thread.Sleep(1000); // 1 masodpercet varjon, mielott ujra ellenorzi
            }  while (!isSorted(array)); // ha az Univerzum is ugy akarja bit-flipek eseten beallhat a rendezettseg. Ennek eselye ~ 0, de != 0;

            return 0;
        }
        
        static void ThreadStart(object i)
        {
            Thread.Sleep(10 * (int)i); // kelloen nagy szorzo kell, nehogy az egyik szal hamarabb lefusson, mint kene
            Console.Write(i + " ");
        }
 
        static void SleepSort(int[] array)
        {
            foreach (var i in array)
                new Thread(ThreadStart).Start(i);
            Console.WriteLine();
        }

        public static bool isSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1]) return false;
            }

            return true;
        }
        
        public static void Main(string[] args)
        {
            //Console.WriteLine(SumRange());
            //MultiplicationTable();
            MinMax3Num();
            /*
            Sum150();
            int[] array = {6, 2, 5, 4, 15, 9, 21};
            Console.WriteLine("Switch count: " + BubbleSort(array));
            Console.WriteLine("Switch count: " + RandomSort(array));
            SolarBitflipSort(array); // Napkitores eseten esely van ra, hogy az elektromagneses hullamok miatt nem ECC RAM-mal rendelkezo gepeken a memoriaban bitflip tortenik es igy esely van egy rendezett tombre
            SleepSort(array); // nem terit vissza szamot, mert nincs valos rendezes
            */
        }
    }
}