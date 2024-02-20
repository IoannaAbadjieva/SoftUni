using System;

namespace P04.Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();
            long sum = 0L;


            foreach (var element in elements)
            {
                try
                {
                    sum += int.Parse(element);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                catch
                {
                    throw;
                }

                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");

            }

            Console.WriteLine($"The total sum of all integers is: {sum}");

        }
    }
}
