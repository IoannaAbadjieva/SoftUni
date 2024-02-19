namespace P02.Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = int.Parse(Console.ReadLine());
            }

            for (int index = numbers.Length - 1; index >= 0; index--)
            {
                Console.Write($"{numbers[index]} ");
            }
        }
    }
}
