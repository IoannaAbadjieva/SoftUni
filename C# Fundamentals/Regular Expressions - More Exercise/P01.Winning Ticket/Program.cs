using System.Text.RegularExpressions;

namespace P01.Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"@{6,}|#{6,}|\${6,}|\^{6,}";

            foreach (string ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string leftHalf = ticket.Substring(0, 10);
                string rightHalf = ticket.Substring(10);

                if (!Regex.Match(leftHalf, pattern).Success || !Regex.Match(rightHalf, pattern).Success)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                string leftMatch = Regex.Match(leftHalf, pattern).Value;
                string rightMatch = Regex.Match(rightHalf, pattern).Value;

                if (leftMatch[0] != rightMatch[0])
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                int minLenght = Math.Min(leftMatch.Length, rightMatch.Length);
                if (minLenght < 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {minLenght}{leftMatch[0]}");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {minLenght}{leftMatch[0]} Jackpot!");
                }

            }
        }
    }
}
