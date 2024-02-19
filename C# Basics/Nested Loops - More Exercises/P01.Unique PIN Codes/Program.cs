namespace P01.Unique_PIN_Codes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max1 = int.Parse(Console.ReadLine());
            int max2 = int.Parse(Console.ReadLine());
            int max3 = int.Parse(Console.ReadLine());


            for (int i = 1; i <= max1; i++)
            {
                for (int j = 2; j <= max2; j++)
                {
                    for (int k = 1; k <= max3; k++)
                    {
                        bool isPrime = true;
                        for (int l = j - 1; l >= 2; l--)
                        {
                            if (j % l == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                        if (i % 2 == 0 && isPrime && k % 2 == 0)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }


                    }
                }
            }
        }
    }
}
