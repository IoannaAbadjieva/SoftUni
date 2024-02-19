namespace P06.Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            char type;

            for (int f = floors; f > 0; f--)
            {
                for (int r = 0; r < rooms; r++)
                {
                    if (f == floors) type = 'L';
                    else if (f % 2 == 0) type = 'O';
                    else type = 'A';
                    Console.Write($"{type}{f}{r} ");
                }
                Console.WriteLine();
            }
        }
    }
}
