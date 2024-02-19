namespace P08.Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

            int magicNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int firstNum = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int secondNum = numbers[j];

                    if (firstNum + secondNum == magicNum)
                    {
                        Console.WriteLine($"{firstNum} {secondNum}");
                    }
                }
            }
        }
    }
}
