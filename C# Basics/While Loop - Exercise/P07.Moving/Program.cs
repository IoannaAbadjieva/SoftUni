namespace P07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int volume = x * y * z;
            string input = "";

            while (volume > 0)
            {
                input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                volume -= int.Parse(input);
            }
            if (volume >= 0)
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
            }
        }
    }
}
