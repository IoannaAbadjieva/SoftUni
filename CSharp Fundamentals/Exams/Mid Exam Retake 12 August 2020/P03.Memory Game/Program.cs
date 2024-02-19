namespace P03.Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;

            int moves = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                int[] indexes = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int firstIndex = indexes[0];
                int secondIndex = indexes[1];

                moves++;

                if (firstIndex == secondIndex || !ValidateIndex(elements, firstIndex) || !ValidateIndex(elements, secondIndex))
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                    elements.Insert(elements.Count / 2, $"-{moves}a");
                    elements.Insert(elements.Count / 2, $"-{moves}a");
                    continue;
                }

                if (elements[firstIndex] == elements[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");

                    elements.RemoveAt(firstIndex);

                    if (firstIndex > secondIndex)
                    {
                        elements.RemoveAt(secondIndex);
                    }
                    else
                    {
                        elements.RemoveAt(secondIndex - 1);
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    return;
                }
            }


            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(' ', elements));

        }

        static bool ValidateIndex(List<string> elements, int index)
        {
            return index >= 0 && index < elements.Count;

        }
    }
}
