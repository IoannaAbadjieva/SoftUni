namespace P08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            int grade = 1;
            int counter = 0;
            double sum = 0.0;

            while (grade <= 12)
            {
                double yearlyGrade = double.Parse(Console.ReadLine());

                if (yearlyGrade < 4)
                {
                    counter++;
                    if (counter == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                    continue;
                }
                grade++;
                sum += yearlyGrade;
            }

            if (counter < 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {sum / 12:f2}");
            }
        }
    }
}
