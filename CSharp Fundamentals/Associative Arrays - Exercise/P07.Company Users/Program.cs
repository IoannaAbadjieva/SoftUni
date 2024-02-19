namespace P07.Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] userInfo = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string company = userInfo[0];
                string userID = userInfo[1];

                if (!companies.ContainsKey(company))
                {
                    companies[company] = new List<string>();
                }

                if (companies[company].Contains(userID))
                {
                    continue;
                }
                companies[company].Add(userID);
            }

            foreach (var item in companies)
            {
                Console.WriteLine(item.Key);
                item.Value.ForEach(x => Console.WriteLine($"-- {x}"));
            }

        }
    }
}
