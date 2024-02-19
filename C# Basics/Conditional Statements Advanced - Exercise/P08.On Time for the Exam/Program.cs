namespace P08.On_Time_for_the_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int aarrivalMin = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMin;
            int arrivalTime = arrivalHour * 60 + aarrivalMin;

            int timeDifference = examTime - arrivalTime;

            if (timeDifference < 0)
            {
                Console.WriteLine("Late");

                timeDifference = Math.Abs(timeDifference);

                if (timeDifference < 60)
                {
                    Console.WriteLine($"{timeDifference % 60} minutes after the start");
                }
                else
                {
                    if (timeDifference % 60 < 10)
                    {
                        Console.WriteLine($"{timeDifference / 60}:0{timeDifference % 60} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{timeDifference / 60}:{timeDifference % 60} hours after the start");
                    }
                }
            }
            else if (timeDifference <= 30)
            {
                Console.WriteLine("On Time");

                if (timeDifference > 0)
                {
                    Console.WriteLine($"{timeDifference % 60} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("Early");
                if (timeDifference < 60)
                {
                    Console.WriteLine($"{timeDifference % 60} minutes before the start");
                }
                else
                {
                    if (timeDifference % 60 < 10)
                    {
                        Console.WriteLine($"{timeDifference / 60}:0{timeDifference % 60} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{timeDifference / 60}:{timeDifference % 60} hours before the start");
                    }
                }
            }

        }
    }
}
