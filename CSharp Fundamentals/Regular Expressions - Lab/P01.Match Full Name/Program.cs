using System.Text.RegularExpressions;

namespace P01.Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);
            Console.WriteLine(String.Join(' ', matches));
        }
    }
}
