namespace P05.Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> add = (numbers) =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i]++;
                }
            };

            Action<int[]> multiply = (numbers) =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] *= 2;
                }
            };

            Action<int[]> subtract = (numbers) =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i]--;
                }
            };

            Action<int[]> print = (numbers) => Console.WriteLine(String.Join(' ', numbers));

            int[] input = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    add(input);
                }
                else if (command == "multiply")
                {
                    multiply(input);
                }
                else if (command == "subtract")
                {
                    subtract(input);
                }
                else
                {
                    print(input);
                }
            }
        }
    }
}
