namespace P02.Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] racersTimes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double leftRacerTime = GetLeftRacerTime(racersTimes);
            double rightRacerTime = GetRightRacerTime(racersTimes);

            if (leftRacerTime < rightRacerTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftRacerTime}");
            }
            else if (leftRacerTime > rightRacerTime)
            {
                Console.WriteLine($"The winner is right with total time: {rightRacerTime}");
            }
        }

        static double GetLeftRacerTime(int[] racersTimes)
        {
            double leftSum = 0;

            for (int index = 0; index < racersTimes.Length / 2; index++)
            {
                int currStepTime = racersTimes[index];
                leftSum += currStepTime;

                if (currStepTime == 0)
                {
                    leftSum -= leftSum * 0.2;
                }
            }
            return leftSum;
        }
        static double GetRightRacerTime(int[] racersTimes)
        {
            double rightSum = 0;

            for (int index = racersTimes.Length - 1; index > racersTimes.Length / 2; index--)
            {
                int currStepTime = racersTimes[index];
                rightSum += currStepTime;

                if (currStepTime == 0)
                {
                    rightSum -= rightSum * 0.20;
                }
            }

            return rightSum;
        }
    }
}
