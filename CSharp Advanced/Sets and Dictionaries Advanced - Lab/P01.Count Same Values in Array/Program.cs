namespace P01.Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                double[] numbers = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Dictionary<double, int> numbersOccurrences = new Dictionary<double, int>();

                foreach (var number in numbers)
                {
                    if (!numbersOccurrences.ContainsKey(number))
                    {
                        numbersOccurrences.Add(number, 0);
                    }
                    numbersOccurrences[number]++;
                }

                foreach (var kvp in numbersOccurrences)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
                }
            }
        }
    }
}
