namespace P02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> judge = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] contestInfo = input
                                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string username = contestInfo[0];
                string contestname = contestInfo[1];
                int points = int.Parse(contestInfo[2]);

                if (!judge.ContainsKey(contestname))
                {
                    judge[contestname] = new Dictionary<string, int>();
                    judge[contestname][username] = points;
                }
                else
                {
                    if (judge[contestname].ContainsKey(username))
                    {
                        if (judge[contestname][username] > points)
                        {
                            continue;
                        }
                    }
                    judge[contestname][username] = points;
                }
            }
            PrintContestsInfo(judge);
            PrintUsersInfo(judge);
        }

        static void PrintContestsInfo(Dictionary<string, Dictionary<string, int>> judge)
        {
            foreach (var contest in judge)
            {
                int position = 1;

                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                foreach (var user in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{position}. {user.Key} <::> {user.Value}");
                    position++;
                }
            }
        }

        static void PrintUsersInfo(Dictionary<string, Dictionary<string, int>> judge)
        {
            Dictionary<string, int> users = GetKeyValuePairs(judge);
            int position = 1;

            Console.WriteLine("Individual standings:");
            foreach (var user in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{position}. {user.Key} -> {user.Value}");
                position++;
            }
        }

        static Dictionary<string, int> GetKeyValuePairs(Dictionary<string, Dictionary<string, int>> judge)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            foreach (var contest in judge)
            {
                foreach (var user in contest.Value)
                {
                    string username = user.Key;

                    if (!keyValuePairs.ContainsKey(username))
                    {
                        keyValuePairs[username] = 0;
                    }
                    keyValuePairs[username] += user.Value;
                }
            }
            return keyValuePairs;
        }
    }
}
