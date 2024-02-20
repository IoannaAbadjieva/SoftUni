using System;

namespace P01.Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(number));
                }
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
           
        }
    }
}
