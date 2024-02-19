namespace P02.Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arguments = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int removeCount = arguments[1];
            int elementToSearch = arguments[2];

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < removeCount; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(queue.Count);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }

        }
    }
}
