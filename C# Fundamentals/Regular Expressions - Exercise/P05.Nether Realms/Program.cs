using System.Text.RegularExpressions;

namespace P05.Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, string> demons = new SortedDictionary<string, string>();

            string[] demonsNames = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string demonName in demonsNames)
            {
                int demonHealth = GetSingleDemonHealth(demonName);
                double demonDamage = GetSingleDemonDamage(demonName);

                if (!demons.ContainsKey(demonName))
                {
                    demons[demonName] = $"{demonHealth}:{demonDamage:f2}";
                }
            }
            PrintDemonsInfo(demons);
        }

        private static void PrintDemonsInfo(SortedDictionary<string, string> demons)
        {
            foreach (var demon in demons)
            {
                string name = demon.Key;
                string health = demon.Value.Split(':')[0];
                string damage = demon.Value.Split(':')[1];
                Console.WriteLine($"{name} - {health} health, {damage} damage");
            }
        }

        static int GetSingleDemonHealth(string demon)
        {
            int health = 0;
            string pattern = @"[^\d+\-*\/.]";
            MatchCollection matches = Regex.Matches(demon, pattern);

            foreach (Match match in matches)
            {
                health += char.Parse(match.Value);
            }
            return health;
        }
        static double GetSingleDemonDamage(string demon)
        {
            double damage = 0;
            string numberssPattern = @"[\+|-]?\d+(\.\d+)?";

            MatchCollection numbersMatches = Regex.Matches(demon, numberssPattern);
            foreach (Match match in numbersMatches)
            {
                damage += double.Parse(match.Value);
            }
      
            string operatorsPattern = @"[*\/]";
            MatchCollection operatorsMatches = Regex.Matches(demon, operatorsPattern);
            foreach (Match match in operatorsMatches)
            {
                if (match.Value == "*")
                {
                    damage *= 2;
                }
                else if (match.Value == "/")
                {
                    damage /= 2;
                }
            }
            return damage;
        }
    }
}
