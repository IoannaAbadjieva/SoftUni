namespace P04.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sumGrades = 0;
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;

            for (int i = 1; i <= n; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                sumGrades += grade;

                if (grade < 3) p4++;
                else if (grade < 4) p3++;
                else if (grade < 5) p2++;
                else p1++;
            }
            p1 = p1 * 100 / n;
            p2 = p2 * 100 / n;
            p3 = p3 * 100 / n;
            p4 = p4 * 100 / n;
            double average = sumGrades / n;

            Console.WriteLine($"Top students: {p1:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {p2:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {p3:f2}%");
            Console.WriteLine($"Fail: {p4:f2}%");
            Console.WriteLine($"Average: {average:f2}");

        }
    }
}
