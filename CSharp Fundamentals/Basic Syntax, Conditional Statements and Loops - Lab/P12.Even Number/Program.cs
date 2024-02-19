namespace P12.Even_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}");
                    break;
                }
                Console.WriteLine("Please write an even number.");
            }
        }
    }
}
