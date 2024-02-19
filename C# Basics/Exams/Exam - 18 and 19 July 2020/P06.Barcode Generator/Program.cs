namespace P06.Barcode_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());


            int i1 = num1 / 1000;
            int j1 = num1 / 100 - i1 * 10;
            int k1 = num1 / 10 - i1 * 100 - j1 * 10;
            int l1 = num1 % 10;
            int i2 = num2 / 1000;
            int j2 = num2 / 100 - i2 * 10;
            int k2 = num2 / 10 - i2 * 100 - j2 * 10;
            int l2 = num2 % 10;


            for (int i = i1; i <= i2; i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = j1; j <= j2; j++)
                    {
                        if (j % 2 != 0)
                        {
                            for (int k = k1; k <= k2; k++)
                            {
                                if (k % 2 != 0)
                                {
                                    for (int l = l1; l <= l2; l++)
                                    {
                                        if (l % 2 != 0)
                                        {
                                            Console.Write($"{i}{j}{k}{l}");
                                            Console.Write(" ");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
