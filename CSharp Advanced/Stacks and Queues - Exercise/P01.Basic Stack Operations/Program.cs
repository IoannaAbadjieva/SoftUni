namespace P01.Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arguments = Console.ReadLine()
         .Split(' ')
         .Select(int.Parse)
         .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int removeCount = arguments[1];
            int elementToSearch = arguments[2];

            Stack<int> stack = new Stack<int>(numbers);

            for (int i = 0; i < removeCount; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(stack.Count);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
