namespace P04.List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }

            products.Sort();

            for (int index = 0; index < products.Count; index++)
            {
                Console.WriteLine($"{index + 1}.{products[index]}");
            }
        }
    }
}
