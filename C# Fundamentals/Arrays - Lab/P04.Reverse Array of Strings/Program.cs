namespace P04.Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine()
               .Split(' ', StringSplitOptions
               .RemoveEmptyEntries).ToArray();

            for (int index = 0; index < items.Length / 2; index++)
            {
                string oldValue = items[index];
                items[index] = items[items.Length - 1 - index];
                items[items.Length - 1 - index] = oldValue;
            }

            Console.WriteLine(string.Join(' ', items));
        }
    }
}
