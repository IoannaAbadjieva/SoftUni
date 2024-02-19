namespace P07.Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            const int capacity = 255;
            int totalQuantity = 0;

            for (int i = 0; i < n; i++)
            {
                int quantity = int.Parse(Console.ReadLine());

                if (totalQuantity + quantity > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                totalQuantity += quantity;
            }

            Console.WriteLine(totalQuantity);
        }
    }
}
