using System.Text.RegularExpressions;
using System.Text;

namespace P04.Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"@(?<planet>[A-Za-z]+)[^@\-!:>]*?:(\d+)[^@\-!:>]*?!(?<attackType>[A|D])![^@\-!:>]*?\-\>(\d+)";
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string decryptedMessage = DecryptMessage(Console.ReadLine());
                Match match = Regex.Match(decryptedMessage, pattern);

                if (match.Success)
                {
                    if (match.Groups["attackType"].Value == "A")
                    {
                        attackedPlanets.Add(match.Groups["planet"].Value);
                    }
                    else
                    {
                        destroyedPlanets.Add(match.Groups["planet"].Value);
                    }
                }
            }
            PrintPlanetsInfo(attackedPlanets, destroyedPlanets);
        }

        private static void PrintPlanetsInfo(List<string> attackedPlanets, List<string> destroyedPlanets)
        {
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        static string DecryptMessage(string encryptedMessage)
        {
            int decryptionKey = GetDecryptionKey(encryptedMessage);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in encryptedMessage)
            {
                sb.Append((char)(ch - decryptionKey));
            }
            return sb.ToString();
        }

        static int GetDecryptionKey(string encryptedMessage)
        {
            string pattern = @"[star]";
            MatchCollection matches = Regex.Matches(encryptedMessage, pattern, RegexOptions.IgnoreCase);
            return matches.Count;
        }
    }
}
