using System;
using System.Collections.Generic;

namespace P02.Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int startNumber = 1;

            while (numbers.Count < 10)
            {
                try
                {
                    int number = ReadNumber(startNumber, 100);
                    numbers.Add(number);
                    startNumber = number;
                }

                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        static int ReadNumber(int startNumber, int endNumber)
        {
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                throw new ArgumentException("Invalid Number!");
            }
            else
            {
                if (!IsNumberInRange(startNumber, endNumber, number))
                {
                    throw new FormatException($"Your number is not in range {startNumber} - 100!");
                }
            }

            return number;
        }

        static bool IsNumberInRange(int startNumber, int endNumber, int number)
        {
            return (number > startNumber) && (number < endNumber);
        }
    }
}
