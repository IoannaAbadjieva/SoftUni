namespace P07.Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(children);
            int tossesCount = 1;

            while (queue.Count > 1)
            {
                string currentChild = queue.Dequeue();
                if (tossesCount == n)
                {
                    Console.WriteLine($"Removed {currentChild}");
                    tossesCount = 1;
                    continue;
                }
                tossesCount++;
                queue.Enqueue(currentChild);
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
