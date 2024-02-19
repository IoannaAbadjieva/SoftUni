namespace P01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string contestName;
            while ((contestName = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = contestName
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                contests.Add(contestInfo[0], contestInfo[1]);
            }

            Dictionary<string, Dictionary<string, int>> ranking = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] userInfo = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                ProccessUsersInfo(userInfo, ranking, contests);
            }
            PrintRanking(ranking);
        }

        static void ProccessUsersInfo(string[] userInfo, Dictionary<string, Dictionary<string, int>> ranking,
            Dictionary<string, string> contests)
        {



            string contest = userInfo[0];
            string password = userInfo[1];
            string username = userInfo[2];
            int points = int.Parse(userInfo[3]);

            if (contests.ContainsKey(contest) && contests[contest] == password)
            {

                if (!ranking.ContainsKey(username))
                {
                    ranking[username] = new Dictionary<string, int>();
                    ranking[username].Add(contest, points);
                }

                if ((ranking[username].ContainsKey(contest) && ranking[username][contest] < points)
                     || !ranking[username].ContainsKey(contest))
                {
                    ranking[username][contest] = points;
                }
            }
        }
        static void PrintRanking(Dictionary<string, Dictionary<string, int>> ranking)
        {

            List<int> pointsSummary = ranking.Select(x => x.Value.Values.Sum()).ToList();

            string bestCandidate = ranking
            .FirstOrDefault(x => x.Value.Values.Sum() == pointsSummary.Max())
            .Key;

            Console.WriteLine($"Best candidate is {bestCandidate} with total {ranking[bestCandidate].Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in ranking.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var results in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {results.Key} -> {results.Value}");
                }
            }
        }
    }
}
