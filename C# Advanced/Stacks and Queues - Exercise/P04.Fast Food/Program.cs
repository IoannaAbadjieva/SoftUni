namespace P04.Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQty = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                if (foodQty < queue.Peek())
                {
                    break;
                }
                foodQty -= queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
            }
        }
    }
}
