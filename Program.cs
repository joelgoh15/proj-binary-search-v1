using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace project9_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("welcome! an appplication that works on using binary search algorithm.");
            Console.WriteLine(); Console.WriteLine();

            int numberOfIntgers;
            bool validInput;
            validInput = false;

            do
            {
                Console.Write("step-1: enter number of integer to generate:");
                numberOfIntgers = Convert.ToInt16(Console.ReadLine().Trim());

                if (numberOfIntgers > 50)
                {
                    Console.WriteLine("number of integer have to be less than 50.");
                }
                else
                {
                    validInput = true;
                }
            } while (!(validInput));

            List<int> numbers = new List<int>();
            Random randomNumbers = new Random();

            for (int i = 0; i < +numberOfIntgers; i++)
            {
                numbers.Add(randomNumbers.Next(1, 1000));
            }

            Console.WriteLine("list of numbers generated:");
            for (int i = 0; i < numberOfIntgers; i++)
            {
                Console.Write("{0} ", numbers[i]);

                if ((i > 0) && ((i % 9) == 0))
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine(); Console.WriteLine();

            int[] numbersArray = numbers.ToArray();
            Array.Sort(numbersArray);

            Console.WriteLine("list of numbers in array generated:");
            for (int i = 0; i < numbersArray.Length; i++)
            {
                Console.Write("{0} ", numbersArray[i]);

                if ((i > 0) && ((i % 9) == 0))
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine(); Console.WriteLine();

            int userInput;
            do
            {
                Console.Write("enter number to search (-1 to exit): ");
                userInput = Convert.ToInt16(Console.ReadLine().Trim());
                int position;
                ClassBinarySearch classBinarySearch = new ClassBinarySearch();
                Timer _timer;
                Stopwatch _stopwatch;
                _stopwatch = new Stopwatch();
                TimerCallback callback = new TimerCallback(TimerTick);
                _timer = new Timer(callback, null, 0, 1000); 
                _stopwatch.Start(); 
                position = classBinarySearch.BinarySearch(userInput, numbersArray);
                _stopwatch.Stop();
                _timer.Dispose(); 
                if (position == -1)
                {
                    Console.WriteLine("the integer {0} was not found. \n", userInput);
                }
                else
                {
                    Console.WriteLine("the integer {0} was found in position {1}. \n", userInput, position);
                    Console.WriteLine("time taken for binary search is {0} seconds.", _stopwatch.Elapsed);
                }
            } while (userInput != -1);

            Console.WriteLine("application exit. press any button to exit.");
            Console.ReadLine();

        }

        static void TimerTick(object state)
        {
            Console.WriteLine("Tick: " + DateTime.Now.ToString("hh:mm:ss"));
        }

    }
}
