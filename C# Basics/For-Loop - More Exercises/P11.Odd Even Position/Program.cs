namespace P11.Odd_Even_Position
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double evenSum = 0.0;
            double evenMinValue = double.MaxValue;
            double evenMaxValue = double.MinValue;
            double oddSum = 0.0;
            double oddMinValue = double.MaxValue;
            double oddMaxValue = double.MinValue;


            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (num < evenMinValue) evenMinValue = num;
                    if (num > evenMaxValue) evenMaxValue = num;
                }
                else
                {
                    oddSum += num;
                    if (num < oddMinValue) oddMinValue = num;
                    if (num > oddMaxValue) oddMaxValue = num;
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");
            if (oddMinValue != double.MaxValue)
            {
                Console.WriteLine($"OddMin={oddMinValue:f2},");
                Console.WriteLine($"OddMax={oddMaxValue:f2},");
            }
            else
            {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (evenMinValue != double.MaxValue)
            {
                Console.WriteLine($"EvenMin={evenMinValue:f2},");
                Console.WriteLine($"EvenMax={evenMaxValue:f2}");
            }
            else
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }

        }
    }
}
