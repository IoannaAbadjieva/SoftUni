namespace P08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsPasswords = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                contestsPasswords[contestInfo[0]] = contestInfo[1];
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] usersInfo = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = usersInfo[0];
                string password = usersInfo[1];
                string username = usersInfo[2];
                int points = int.Parse(usersInfo[3]);

                if (!contestsPasswords.ContainsKey(contest) || contestsPasswords[contest] != password)
                {
                    continue;
                }

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, int>());
                }

                if (!users[username].ContainsKey(contest))
                {
                    users[username].Add(contest, points);
                }
                else
                {
                    if (users[username][contest] < points)
                    {
                        users[username][contest] = points;
                    }
                }
            }

            string bestCandidate = users.OrderByDescending(x => x.Value.Values.Sum()).First().Key;
            int bestCandidatePoints = users[bestCandidate].Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users)
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
