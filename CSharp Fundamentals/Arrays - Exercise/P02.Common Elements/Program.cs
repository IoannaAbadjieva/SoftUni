namespace P02.Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            string[] secondArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int index = 0; index < secondArray.Length; index++)
            {
                if (firstArray.Contains(secondArray[index]))
                {
                    Console.Write($"{secondArray[index]} ");
                }
            }
        }
    }
}
