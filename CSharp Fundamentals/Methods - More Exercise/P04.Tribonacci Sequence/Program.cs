using System.Numerics;

namespace P04.Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(" ", Tribonacci(num)));
        }

        static BigInteger[] Tribonacci(int num)
        {
            BigInteger[] numbers = new BigInteger[num];

            for (int i = 0; i < num; i++)
            {
                if (i == 0 || i == 1)
                {
                    numbers[i] = 1;
                }
                else if (i == 2)
                {
                    numbers[i] = 2;
                }
                else
                {
                    numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i - 3];
                }
            }
            return numbers;
        }
    }
}
