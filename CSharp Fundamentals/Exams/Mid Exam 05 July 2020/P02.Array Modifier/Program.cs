namespace P02.Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(long.Parse)
    .ToArray();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArgs[0];

                if (type == "swap")
                {
                    int indexOfFirstElemnt = int.Parse(cmdArgs[1]);
                    int indexOfSecondElement = int.Parse(cmdArgs[2]);

                    long elementValue = numbers[indexOfFirstElemnt];
                    numbers[indexOfFirstElemnt] = numbers[indexOfSecondElement];
                    numbers[indexOfSecondElement] = elementValue;
                }
                else if (type == "multiply")
                {
                    int indexOfFirstElemnt = int.Parse(cmdArgs[1]);
                    int indexOfSecondElement = int.Parse(cmdArgs[2]);

                    numbers[indexOfFirstElemnt] *= numbers[indexOfSecondElement];
                }
                else if (type == "decrease")
                {
                    for (int index = 0; index < numbers.Length; index++)
                    {
                        numbers[index]--;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
