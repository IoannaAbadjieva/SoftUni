namespace P11.Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" ");

                if (cmdArgs[0] == "exchange")
                {
                    int exchangeIndex = int.Parse(cmdArgs[1]);

                    if (exchangeIndex < 0 || exchangeIndex >= input.Length)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    input = ExchangeArrayElements(input, exchangeIndex);
                }
                else if (cmdArgs[0] == "max" || cmdArgs[0] == "min")
                {
                    int index;
                    string type = cmdArgs[0];
                    string oddOrEven = cmdArgs[1];

                    if (type == "max")
                    {
                        index = GetMaxEvenOddElementIndex(input, oddOrEven);
                    }
                    else
                    {
                        index = GetMinEvenOddElementIndex(input, oddOrEven);
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {

                        Console.WriteLine(index);
                    }
                }
                else if (cmdArgs[0] == "first" || cmdArgs[0] == "last")
                {
                    string type = cmdArgs[0];
                    int count = int.Parse(cmdArgs[1]);
                    string oddOrEven = cmdArgs[2];

                    if (count > input.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if (type == "first")
                    {
                        GetFirstEvenOddElements(input, count, oddOrEven);
                    }
                    else
                    {
                        GetLastEvenOddElements(input, count, oddOrEven);
                    }

                }
            }
            PrintArrayToString(input, input.Length);
        }

        static int[] ExchangeArrayElements(int[] array, int exchangeIndex)
        {

            int[] exchangedArr = new int[array.Length];

            int index = 0;

            for (int i = exchangeIndex + 1; i < array.Length; i++)
            {
                exchangedArr[index] = array[i];
                index++;
            }

            for (int i = 0; i <= exchangeIndex; i++)
            {
                exchangedArr[index] = array[i];
                index++;
            }

            return exchangedArr;
        }

        static int GetMaxEvenOddElementIndex(int[] array, string evenOrOdd)
        {
            int maxValue = int.MinValue;
            int maxValueIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                int currElement = array[i];

                if (evenOrOdd == "even")
                {
                    if (currElement % 2 == 0 && currElement >= maxValue)
                    {
                        maxValue = currElement;
                        maxValueIndex = i;
                    }
                }
                else if (evenOrOdd == "odd")
                {
                    if (currElement % 2 != 0 && currElement >= maxValue)
                    {
                        maxValue = currElement;
                        maxValueIndex = i;
                    }
                }
            }

            return maxValueIndex;
        }

        static int GetMinEvenOddElementIndex(int[] array, string evenOrOdd)
        {
            int minValue = int.MaxValue;
            int minValueIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                int currElement = array[i];

                if (evenOrOdd == "even")
                {
                    if (currElement % 2 == 0 && currElement <= minValue)
                    {
                        minValue = currElement;
                        minValueIndex = i;
                    }
                }
                else if (evenOrOdd == "odd")
                {
                    if (currElement % 2 != 0 && currElement <= minValue)
                    {
                        minValue = currElement;
                        minValueIndex = i;
                    }
                }
            }

            return minValueIndex;
        }

        static void GetFirstEvenOddElements(int[] array, int count, string evenOrOdd)
        {
            int[] firstElements = new int[count];
            int firstElementsIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int currElement = array[i];

                if (evenOrOdd == "even")
                {
                    if (currElement % 2 == 0 && firstElementsIndex < count)
                    {
                        firstElements[firstElementsIndex] = currElement;
                        firstElementsIndex++;
                    }
                }
                else if (evenOrOdd == "odd")
                {
                    if (currElement % 2 != 0 && firstElementsIndex < count)
                    {
                        firstElements[firstElementsIndex] = currElement;
                        firstElementsIndex++;
                    }
                }
            }

            PrintArrayToString(firstElements, firstElementsIndex);
        }

        static void GetLastEvenOddElements(int[] array, int count, string evenOrOdd)
        {
            int[] lastElements = new int[count];
            int lastElementsIndex = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int currElement = array[i];

                if (evenOrOdd == "even")
                {
                    if (currElement % 2 == 0 && lastElementsIndex < count)
                    {
                        lastElements[lastElementsIndex] = currElement;
                        lastElementsIndex++;
                    }
                }
                else if (evenOrOdd == "odd")
                {
                    if (currElement % 2 != 0 && lastElementsIndex < count)
                    {
                        lastElements[lastElementsIndex] = currElement;
                        lastElementsIndex++;
                    }
                }
            }

            int[] reversed = new int[lastElementsIndex];

            int reversedIndex = 0;

            for (int index = lastElementsIndex - 1; index >= 0; index--)
            {
                reversed[reversedIndex] = lastElements[index];
                reversedIndex++;
            }

            PrintArrayToString(reversed, reversedIndex);
        }

        static void PrintArrayToString(int[] array, int count)
        {
            Console.Write("[");

            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    Console.Write(array[i]);
                }
                else
                {
                    Console.Write(array[i] + ", ");
                }
            }
            Console.WriteLine("]");
        }
    }
}
