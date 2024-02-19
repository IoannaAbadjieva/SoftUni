namespace P02.Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int failed = 0;
            int solvedProblems = 0;
            int gradesSum = 0;
            int grade = 0;
            string lastProblem = "";

            string input = Console.ReadLine();
            while (input != "Enough")
            {
                lastProblem = input;
                grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    failed++;
                    if (failed == n)
                    {
                        Console.WriteLine($"You need a break, {failed} poor grades.");
                        break;
                    }
                }
                solvedProblems++;
                gradesSum += grade;
                input = Console.ReadLine();
            }

            if (input == "Enough")
            {
                Console.WriteLine($"Average score: {gradesSum * 1.0 / solvedProblems:f2}");
                Console.WriteLine($"Number of problems: {solvedProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }


        }
    }
}
