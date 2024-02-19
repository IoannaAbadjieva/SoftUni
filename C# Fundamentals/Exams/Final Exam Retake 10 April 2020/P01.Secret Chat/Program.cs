namespace P01.Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] cmdArgs = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "InsertSpace")
                {
                    int indexToInsertAt = int.Parse(cmdArgs[1]);
                    message = message.Insert(indexToInsertAt, " ");

                }
                else if (cmdType == "Reverse")
                {
                    string subStr = cmdArgs[1];
                    if (!message.Contains(subStr))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    int startIndex = message.IndexOf(subStr);
                    message = message.Remove(startIndex, subStr.Length);
                    message = $"{message}{string.Join("", subStr.Reverse())}";

                }
                else if (cmdType == "ChangeAll")
                {
                    string subStr = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    if (message.Contains(subStr))
                    {
                        message = message.Replace(subStr, replacement);
                    }
                }
                else
                {
                    continue;
                }
                Console.WriteLine(message);
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
