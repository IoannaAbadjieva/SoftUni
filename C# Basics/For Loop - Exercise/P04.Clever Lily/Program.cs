namespace P04.Clever_Lily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachine = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int moneySaved = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0) moneySaved += i * 5 - 1;
                else moneySaved += toyPrice;
            }

            if (moneySaved >= washingMachine)
            {
                Console.WriteLine($"Yes! {moneySaved - washingMachine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachine - moneySaved:f2}");
            }
        }
    }
}
