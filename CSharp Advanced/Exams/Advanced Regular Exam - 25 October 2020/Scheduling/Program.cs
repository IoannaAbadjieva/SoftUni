namespace Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tasksValues = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] threadsValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int taskToBeKilled = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksValues);
            Queue<int> threads = new Queue<int>(threadsValues);

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (task == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {taskToBeKilled}");
                    break;
                }

                if (thread >= task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(String.Join(' ', threads));
        }
    }
}
