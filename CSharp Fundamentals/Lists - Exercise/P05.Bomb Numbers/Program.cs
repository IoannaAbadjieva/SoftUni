namespace P05.Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int[] bombInfo = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            int bombNumber = bombInfo[0];
            int bombPower = bombInfo[1];
            int bombIndex;

            while ((bombIndex = numbers.IndexOf(bombNumber)) != -1)
            {
                DetonateBomb(numbers, bombIndex, bombPower);
            }

            Console.WriteLine(numbers.Sum());
        }

        static void DetonateBomb(List<int> numbers, int bombIndex, int bombPower)
        {
            int leftMargin = bombIndex - bombPower;

            if (leftMargin < 0)
            {
                leftMargin = 0;
            }

            int rightMargin = bombIndex + bombPower;

            if (rightMargin >= numbers.Count)
            {
                rightMargin = numbers.Count - 1;
            }

            for (int cnt = leftMargin; cnt <= rightMargin; cnt++)
            {
                numbers.RemoveAt(leftMargin);
            }
        }
    }
}
