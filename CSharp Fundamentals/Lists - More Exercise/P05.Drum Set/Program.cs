namespace P05.Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> drumSet = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> initialQuality = new List<int>();
            initialQuality.AddRange(drumSet);

            string input;
            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitPower;

                    if (drumSet[i] <= 0)
                    {
                        if (savings >= 3 * initialQuality[i])
                        {
                            drumSet[i] = initialQuality[i];
                            savings -= 3 * initialQuality[i];
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            initialQuality.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
