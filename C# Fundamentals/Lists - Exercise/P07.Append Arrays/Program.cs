namespace P07.Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrays = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<int> appendedArrays = new List<int>();

            for (int i = arrays.Length - 1; i >= 0; i--)
            {
                int[] currArray = arrays[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                appendedArrays.AddRange(currArray);
            }

            Console.WriteLine(string.Join(" ", appendedArrays));
        }
    }
}
