using System.Text.RegularExpressions;

namespace P02.Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359( |-)[2]\1[0-9]{3}\1[0-9]{4}\b";

            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);

            string[] phones = matches
                .Cast<Match>()
                .Select(x => x.Value)
                .ToArray();

            Console.WriteLine(String.Join(", ", phones));
        }
    }
}
