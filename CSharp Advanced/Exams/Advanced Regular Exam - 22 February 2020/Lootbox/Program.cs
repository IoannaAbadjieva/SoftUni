namespace Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> claimedItems = new List<int>();

            int[] firstBoxItems = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondBoxItems = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<int> firstBox = new Queue<int>(firstBoxItems);
            Stack<int> secondBox = new Stack<int>(secondBoxItems);

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstItem = firstBox.Peek();
                int secondItem = secondBox.Pop();

                if ((firstItem + secondItem) % 2 == 0)
                {
                    claimedItems.Add(firstItem + secondItem);
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(secondItem);
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }

        }
    }
}
