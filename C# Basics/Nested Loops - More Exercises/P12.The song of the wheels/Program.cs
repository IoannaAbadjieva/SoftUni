namespace P12.The_song_of_the_wheels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int control = int.Parse(Console.ReadLine());
            int counter = 0;
            int password = 0;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = a + 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d < c; d++)
                        {
                            if ((a * b + c * d) == control)
                            {
                                Console.Write($"{a}{b}{c}{d} ");
                                counter++;
                                if (counter == 4)
                                {
                                    password = a * 1000 + b * 100 + c * 10 + d;
                                }
                            }

                        }
                    }
                }

            }
            if (password == 0)
            {
                Console.WriteLine("\nNo!");
            }
            else
            {
                Console.WriteLine($"\nPassword: {password}");
            }
        }
    }
}
