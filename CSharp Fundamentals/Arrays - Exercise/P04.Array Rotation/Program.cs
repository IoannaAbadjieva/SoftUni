namespace P04.Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            int rotations = int.Parse(Console.ReadLine());
            int rotationsCount = rotations % numbers.Length;

            for (int count = 1; count <= rotationsCount; count++)
            {
                int firstElementValue = numbers[0];

                for (int index = 0; index < numbers.Length - 1; index++)
                {
                    numbers[index] = numbers[index + 1];
                }

                numbers[numbers.Length - 1] = firstElementValue;
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
