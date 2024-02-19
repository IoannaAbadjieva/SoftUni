namespace P02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                double grade = double.Parse(Console.ReadLine());
                PrintDefinitionOfGrade(grade);
            }

            static void PrintDefinitionOfGrade(double grade)
            {
                if (grade >= 2.0 && grade <= 2.99)
                {
                    Console.WriteLine("Fail");
                }
                else if (grade > 2.99 && grade <= 3.49)
                {
                    Console.WriteLine("Poor");
                }
                else if (grade > 3.49 && grade <= 4.49)
                {
                    Console.WriteLine("Good");
                }
                else if (grade > 4.49 && grade <= 5.49)
                {
                    Console.WriteLine("Very good");
                }
                else if (grade > 5.49 && grade <= 6.00)
                {
                    Console.WriteLine("Excellent");
                }
            }
        }
    }
}
