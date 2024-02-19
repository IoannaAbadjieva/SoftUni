namespace P04.Train_The_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string presentation = Console.ReadLine();
            double finalAssesment = 0.0;
            int counter = 0;
            while (presentation != "Finish")
            {
                counter++;
                double average = 0.0;
                for (int i = 1; i <= n; i++)
                {
                    average += double.Parse(Console.ReadLine());
                }
                average = average / n;
                Console.WriteLine($"{presentation} - {average:f2}.");
                finalAssesment += average;
                presentation = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {finalAssesment / counter:f2}.");
        }
    }
}
