namespace P06.List_Manipulation_Basics
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

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "Add")
                {
                    int numberToAdd = int.Parse(cmdArgs[1]);
                    numbers.Add(numberToAdd);
                }
                else if (cmdType == "Remove")
                {
                    int numberToRemove = int.Parse(cmdArgs[1]);
                    numbers.Remove(numberToRemove);
                }
                else if (cmdType == "RemoveAt")
                {
                    int indexToRemove = int.Parse(cmdArgs[1]);
                    numbers.RemoveAt(indexToRemove);
                }
                else if (cmdType == "Insert")
                {
                    int numberToInsert = int.Parse(cmdArgs[1]);
                    int indexToInsertAt = int.Parse(cmdArgs[2]);

                    numbers.Insert(indexToInsertAt, numberToInsert);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
