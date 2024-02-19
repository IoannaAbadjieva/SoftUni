namespace P01.Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 3;

            PrintSmallestNumber(n);
        }

        static void PrintSmallestNumber(int numsCount)
        {
            int minValue = int.MaxValue;

            for (int i = 0; i < numsCount; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (currNum < minValue)
                {
                    minValue = currNum;
                }
            }

            Console.WriteLine(minValue);
        }
    }
}
