namespace P07.List_Manipulation_Advanced
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
            bool isListChanged = false;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "Add")
                {
                    int numberToAdd = int.Parse(cmdArgs[1]);
                    numbers.Add(numberToAdd);
                    isListChanged = true;
                }
                else if (cmdType == "Remove")
                {
                    int numberToRemove = int.Parse(cmdArgs[1]);
                    numbers.Remove(numberToRemove);
                    isListChanged = true;
                }
                else if (cmdType == "RemoveAt")
                {
                    int indexToRemove = int.Parse(cmdArgs[1]);
                    numbers.RemoveAt(indexToRemove);
                    isListChanged = true;
                }
                else if (cmdType == "Insert")
                {
                    int numberToInsert = int.Parse(cmdArgs[1]);
                    int indexToInsertAt = int.Parse(cmdArgs[2]);

                    numbers.Insert(indexToInsertAt, numberToInsert);
                    isListChanged = true;
                }
                else if (cmdType == "Contains")
                {
                    int numberToContain = int.Parse(cmdArgs[1]);

                    if (numbers.Contains(numberToContain))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (cmdType == "PrintOdd")
                {
                    List<int> odds = numbers.FindAll(x => x % 2 != 0);
                    Console.WriteLine(string.Join(" ", odds));
                }
                else if (cmdType == "PrintEven")
                {
                    List<int> evens = numbers.FindAll(x => x % 2 == 0);
                    Console.WriteLine(string.Join(" ", evens));
                }
                else if (cmdType == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (cmdType == "Filter")
                {
                    string condition = cmdArgs[1];
                    int numberToCompare = int.Parse(cmdArgs[2]);

                    PrintFilteredList(numbers, condition, numberToCompare);
                }
            }
            if (isListChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static void PrintFilteredList(List<int> numbers, string condition, int compare)
        {
            List<int> filtered = new List<int>();

            if (condition == "<")
            {
                filtered = numbers.FindAll(x => x < compare);
            }
            else if (condition == ">")
            {
                filtered = numbers.FindAll(x => x > compare);
            }
            else if (condition == "<=")
            {
                filtered = numbers.FindAll(x => x <= compare);
            }
            else if (condition == ">=")
            {
                filtered = numbers.FindAll(x => x >= compare);
            }

            Console.WriteLine(string.Join(" ", filtered));
        }
    }
}
