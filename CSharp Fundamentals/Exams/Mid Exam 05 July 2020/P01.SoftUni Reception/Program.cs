namespace P01.SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int studentsPerHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
            int hoursNeeded = (int)Math.Ceiling(students * 1.0 / studentsPerHour);
            int breaks = hoursNeeded / 3;

            if (hoursNeeded % 3 == 0 && hoursNeeded > 0)
            {
                breaks--;
            }

            hoursNeeded += breaks;
            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
