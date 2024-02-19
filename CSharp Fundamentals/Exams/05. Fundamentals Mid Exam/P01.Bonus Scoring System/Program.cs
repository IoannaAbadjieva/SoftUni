namespace P01.Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int maxAttendances = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                double totalBonus = attendances * 1.0 / lecturesCount * (5 + additionalBonus);

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendances = attendances;
                }

            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");
        }
    }
}
