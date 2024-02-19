namespace P07.Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] currPump = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                queue.Enqueue(currPump);
            }


            bool isStartFound = false;
            int indexOfStartingPump = 0;

            while (!isStartFound)
            {
                int fuel = 0;
                int counter = 0;
                for (int i = 0; i < queue.Count; i++)
                {
                    fuel += queue.Peek()[0];
                    fuel -= queue.Peek()[1];
                    queue.Enqueue(queue.Dequeue());

                    if (fuel >= 0)
                    {
                        counter++;
                    }
                }

                if (counter == n)
                {
                    isStartFound = true;
                    break;
                }
                queue.Enqueue(queue.Dequeue());
                indexOfStartingPump++;
            }
            Console.WriteLine(indexOfStartingPump);

        }
    }
}
