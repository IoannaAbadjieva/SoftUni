namespace P04.Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currNumber))
                {
                    numbers.Add(currNumber, 0);
                }
                numbers[currNumber]++;
            }

            Console.WriteLine(numbers.Single(x => x.Value % 2 == 0).Key);
        }
    }
}
