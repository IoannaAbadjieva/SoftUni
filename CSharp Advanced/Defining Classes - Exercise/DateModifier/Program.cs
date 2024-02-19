using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDateAsString = Console.ReadLine();
            string endDateAsString = Console.ReadLine();

            int difference = DateModifier.DateDifference(startDateAsString, endDateAsString);

            Console.WriteLine(difference);
        }
    }
}
