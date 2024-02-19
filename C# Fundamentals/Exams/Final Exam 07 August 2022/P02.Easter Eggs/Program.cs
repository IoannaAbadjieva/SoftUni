using System;
using System.Text.RegularExpressions;

namespace P02.Easter_Eggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[@#]+(?<color>[a-z]{3,})[@#]+[^A-Za-z0-9]*\/(?<count>\d+)\/";
           

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string color = match.Groups["color"].Value;
                int count = int.Parse(match.Groups["count"].Value);

                Console.WriteLine($"You found {count} {color} eggs!");
            }
            
        }
    }
}
