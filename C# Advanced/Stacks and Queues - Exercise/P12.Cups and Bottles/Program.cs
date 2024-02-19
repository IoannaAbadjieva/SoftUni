namespace P12.Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bottlesInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsInfo);
            Stack<int> bottles = new Stack<int>(bottlesInfo);

            int wastedWater = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int bottle = bottles.Pop();
                int cup = cups.Dequeue();

                if (bottle >= cup)
                {
                    wastedWater += bottle - cup;
                }
                else
                {
                    cup -= bottle;
                    cups.Enqueue(cup);
                    for (int i = 0; i < cups.Count - 1; i++)
                    {
                        cups.Enqueue(cups.Dequeue());
                    }
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");

        }
    }
}
