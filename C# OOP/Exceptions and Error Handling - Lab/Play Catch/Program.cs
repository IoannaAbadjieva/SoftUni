using System;
using System.Linq;

namespace P05.Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                try
                {
                    ProcessComand(numbers, ref exceptionsCount);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (IndexOutOfRangeException iooe)
                {
                    Console.WriteLine(iooe.Message);
                }
                catch
                {
                    throw;
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        static void ProcessComand(int[] numbers, ref int exceptionsCount)
        {
            string[] cmdArgs = Console.ReadLine().Split();

            string cmdType = cmdArgs[0];
            string firstArg = cmdArgs[1];

            if (!int.TryParse(firstArg, out int index))
            {
                exceptionsCount++;
                throw new FormatException("The variable is not in the correct format!");
            }

            if (!IsIndexValid(numbers, index))
            {
                exceptionsCount++;
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            if (cmdType == "Replace")
            {
                string secondArg = cmdArgs[2];

                if (!int.TryParse(secondArg, out int element))
                {
                    exceptionsCount++;
                    throw new FormatException("The variable is not in the correct format!");
                }

                numbers[index] = element;
            }
            else if (cmdType == "Print")
            {
                string secondArg = cmdArgs[2];

                if (!int.TryParse(secondArg, out int endIndex))
                {
                    exceptionsCount++;
                    throw new FormatException("The variable is not in the correct format!");
                }

                if (!IsIndexValid(numbers, endIndex))
                {
                    exceptionsCount++;
                    throw new IndexOutOfRangeException("The index does not exist!");
                }

                int[] numsToPrint = numbers.Skip(index).Take(endIndex - index + 1).ToArray();
                Console.WriteLine(String.Join(", ", numsToPrint));
            }
            else if (cmdType == "Show")
            {
                Console.WriteLine(numbers[index]);
            }

        }

        static bool IsIndexValid(int[] numbers, int index)
        {
            return index >= 0 && index < numbers.Length;
        }
    }
}
