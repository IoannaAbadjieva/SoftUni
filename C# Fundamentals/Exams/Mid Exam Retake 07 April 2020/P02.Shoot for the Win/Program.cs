namespace P02.Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            string input;
            int count = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                int targetIndex = int.Parse(input);

                if (!ValidateIndex(targets, targetIndex))
                {
                    continue;
                }

                if (targets[targetIndex] == -1)
                {
                    continue;
                }

                int targetValue = targets[targetIndex];
                targets[targetIndex] = -1;
                count++;

                for (int index = 0; index < targets.Length; index++)
                {
                    int current = targets[index];

                    if (current != -1)
                    {
                        if (current > targetValue)
                        {
                            targets[index] -= targetValue;
                        }
                        else
                        {
                            targets[index] += targetValue;
                        }
                    }
                }
            }

            Console.Write($"Shot targets: {count} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }

        static bool ValidateIndex(int[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }
    }
}
