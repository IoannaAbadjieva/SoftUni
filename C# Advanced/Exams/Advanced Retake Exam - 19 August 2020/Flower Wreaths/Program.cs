namespace Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int FlowersNeddedForWreath = 15;
            const int MinWreathCount = 5;

            List<int> storedFlowers = new List<int>();

            int[] liliesQtys = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[] RosesQtys = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> lilies = new Stack<int>(liliesQtys);
            Queue<int> roses = new Queue<int>(RosesQtys);

            int wreathsCount = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int liliesCount = lilies.Pop();
                int rosesCount = roses.Peek();

                int flowersCount = liliesCount + rosesCount;

                if (flowersCount == FlowersNeddedForWreath)
                {
                    wreathsCount++;
                    roses.Dequeue();
                }
                else if (flowersCount < FlowersNeddedForWreath)
                {
                    storedFlowers.Add(flowersCount);
                    roses.Dequeue();
                }
                else
                {
                    lilies.Push(liliesCount - 2);
                }
            }

            wreathsCount += storedFlowers.Sum() / FlowersNeddedForWreath;

            if (wreathsCount >= MinWreathCount)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {MinWreathCount - wreathsCount} wreaths more!");
            }
        }
    }
}
