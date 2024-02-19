namespace P08.Lunch_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Име на сериал – текст
            //2.Продължителност на епизод  – цяло число в диапазона[10… 90]
            //3.Продължителност на почивката  – цяло число в диапазона[10… 120]

            string seriasName = Console.ReadLine();
            int seriasTime = int.Parse(Console.ReadLine());
            int lunchBreakTime = int.Parse(Console.ReadLine());

            //време за обяд - 1/8 от времето за почивка
            //време за отдих - 1/4 от времето за почивка

            double timeForWatch = 5.0 * lunchBreakTime / 8;


            if (timeForWatch >= seriasTime)
            {
                Console.WriteLine($"You have enough time to watch {seriasName} and left with " +
                    $"{Math.Ceiling(timeForWatch - seriasTime)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriasName}, you need " +
                    $"{Math.Ceiling(seriasTime - timeForWatch)} more minutes.");
            }

        }
    }
}
