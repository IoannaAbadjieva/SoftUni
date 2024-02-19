namespace P06.Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string cmdType = cmdArgs[0];

                if (cmdType == "Play")
                {
                    queue.Dequeue();
                }
                else if (cmdType == "Add")
                {
                    string songToAdd = string.Join(" ", cmdArgs.Skip(1));
                    if (queue.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                        continue;
                    }
                    queue.Enqueue(songToAdd);
                }
                else if (cmdType == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
