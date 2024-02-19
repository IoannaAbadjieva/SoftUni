using System.Text;

namespace P01.Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "TakeOdd")
                {
                    password = TakeOdds(password);
                }
                else if (cmdType == "Cut")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int lenght = int.Parse(cmdArgs[2]);
                    password = password.Remove(startIndex, lenght);
                }
                else if (cmdType == "Substitute")
                {
                    string substring = cmdArgs[1];
                    string substitute = cmdArgs[2];
                    if (!password.Contains(substring))
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }
                    password = password.Replace(substring, substitute);
                }
                else
                {
                    continue;
                }
                Console.WriteLine(password);
            }
            Console.WriteLine($"Your password is: {password}");
        }

        static string TakeOdds(string password)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < password.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sb.Append(password[i]);
                }
            }
            return sb.ToString();
        }
    }
}
