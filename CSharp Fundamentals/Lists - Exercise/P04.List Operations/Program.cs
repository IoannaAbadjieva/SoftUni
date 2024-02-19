namespace P04.List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "Add")
                {
                    int numberToAdd = int.Parse(cmdArgs[1]);
                    numbers.Add(numberToAdd);
                }
                else if (cmdType == "Insert")
                {
                    int numberToInsert = int.Parse(cmdArgs[1]);
                    int indexToInsertAt = int.Parse(cmdArgs[2]);

                    if (!IsIndexValid(numbers, indexToInsertAt))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(indexToInsertAt, numberToInsert);
                }
                else if (cmdType == "Remove")
                {
                    int indexToRemoveAt = int.Parse(cmdArgs[1]);

                    if (!IsIndexValid(numbers, indexToRemoveAt))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(indexToRemoveAt);
                }
                else if (cmdType == "Shift")
                {
                    string direction = cmdArgs[1];
                    int count = int.Parse(cmdArgs[2]);

                    if (direction == "left")
                    {
                        ShiftListLeft(numbers, count);
                    }
                    else if (direction == "right")
                    {
                        ShiftListRight(numbers, count);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        static bool IsIndexValid(List<int> numbers, int index)
        {
            return index >= 0 && index < numbers.Count;
        }

        static void ShiftListLeft(List<int> numbers, int count)
        {
            int shiftsCount = count % numbers.Count;

            for (int i = 0; i < shiftsCount; i++)
            {
                int firstElement = numbers.First();
                numbers.RemoveAt(0);
                numbers.Add(firstElement);
            }
        }

        static void ShiftListRight(List<int> numbers, int count)
        {
            int shiftsCount = count % numbers.Count;

            for (int i = 0; i < shiftsCount; i++)
            {
                int lastElement = numbers.Last();
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, lastElement);
            }
        }
    }
}
