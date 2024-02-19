namespace P02.Change_List
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
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "Delete")
                {
                    int numberToDelete = int.Parse(cmdArgs[1]);
                    numbers.RemoveAll(x => x == numberToDelete);
                }
                else if (cmdType == "Insert")
                {
                    int numberToInsert = int.Parse(cmdArgs[1]);
                    int indexToInsertAt = int.Parse(cmdArgs[2]);
                    numbers.Insert(indexToInsertAt, numberToInsert);
                }
            }

            Console.WriteLine(string.Join(" ", numbers)); ;
        }
    }
}
