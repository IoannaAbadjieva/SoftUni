namespace P09.SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> users = new SortedDictionary<string, int>();
            SortedDictionary<string, int> submissions = new SortedDictionary<string, int>();

            string command;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] cmdArgs = command.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = cmdArgs[0];

                if (cmdArgs.Length == 2)
                {
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                }
                else
                {
                    string language = cmdArgs[1];
                    int points = int.Parse(cmdArgs[2]);

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, 0);
                    }

                    if (points > users[username])
                    {
                        users[username] = points;
                    }
                }
            }

            Console.WriteLine("Results:");

            foreach (var user in users.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }
            Console.WriteLine("Submissions:");

            foreach (var language in submissions.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }

        }
    }
}
