using System.Text.RegularExpressions;
using System.Text;

namespace P04.Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> goodChildren = new List<string>();
            string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*?!G!";
            int decriptionKey = int.Parse(Console.ReadLine());

            string enctyptedMessage;
            while ((enctyptedMessage = Console.ReadLine()) != "end")
            {
                string message = DecryptMessage(enctyptedMessage, decriptionKey);
                Match match = Regex.Match(message, pattern);
                if (match.Success)
                {
                    goodChildren.Add(match.Groups["name"].Value);
                }
            }
            goodChildren.ForEach(x => Console.WriteLine(x));
        }

        private static string DecryptMessage(string enctyptedMessage, int decriptionKey)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in enctyptedMessage)
            {
                sb.Append((char)(ch - decriptionKey));
            }
            return sb.ToString();
        }
    }
}
