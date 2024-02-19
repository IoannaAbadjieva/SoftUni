namespace P03.Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            PrintCharactersBetween(first, second);
        }

        static void PrintCharactersBetween(char first, char second)
        {
            int start;
            int end;

            if (first < second)
            {
                start = first + 1;
                end = second;
            }
            else
            {
                start = second + 1;
                end = first;
            }

            for (int i = start; i < end; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
