using System;

namespace P01.ExperienceGaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            double totalExperience = 0;


            for (int battle = 1; battle <= count; battle++)
            {
                double experienceForBattle = double.Parse(Console.ReadLine());

                totalExperience += experienceForBattle;

                if (battle % 3 == 0)
                {
                    totalExperience += experienceForBattle * 0.15;
                }

                if (battle % 5 == 0)
                {
                    totalExperience -= experienceForBattle * 0.10;
                }

                if (battle % (3 * 5) == 0)
                {
                    totalExperience += experienceForBattle * 0.05;
                }


                if (totalExperience >= neededExperience)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battle} battles.");
                    return;
                }
            }

            Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience - totalExperience:f2} more needed.");
        }
    }
}
