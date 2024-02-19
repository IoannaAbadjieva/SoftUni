namespace P08.Secret_Door_s_Lock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hundreds = int.Parse(Console.ReadLine());
            int tens = int.Parse(Console.ReadLine());
            int units = int.Parse(Console.ReadLine());

            for (int h = 1; h <= hundreds; h++)
            {
                for (int t = 2; t <= tens; t++)
                {
                    bool isPrime = true;
                    for (int i = t - 1; i >= 2; i--)
                    {
                        if (t % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    for (int u = 1; u <= units; u++)
                    {

                        if (h % 2 == 0 && isPrime && u % 2 == 0)
                            Console.WriteLine($"{h} {t} {u}");
                    }
                }
            }

        }
    }
}
