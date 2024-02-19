namespace P02.Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "add")
                {
                    stack.Push(int.Parse(cmdArgs[1]));
                    stack.Push(int.Parse(cmdArgs[2]));
                }
                else if (cmdArgs[0] == "remove")
                {
                    if (int.Parse(cmdArgs[1]) > stack.Count)
                    {
                        continue;
                    }
                    for (int i = 0; i < int.Parse(cmdArgs[1]); i++)
                    {
                        stack.Pop();
                    }

                }
            }
            if (stack.Count > 0)
            {
                Console.WriteLine($"Sum: {stack.Sum()}"); ;
            }
        }
    }
}
