namespace P01.Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string command;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] cmdArgs = command
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "Contains")
                {
                    string subString = cmdArgs[1];
                    Contains(activationKey, subString);
                }
                else if (cmdType == "Flip")
                {
                    string casing = cmdArgs[1];
                    int startIndex = int.Parse(cmdArgs[2]);
                    int endIndex = int.Parse(cmdArgs[3]);

                    activationKey = Flip(activationKey, casing, startIndex, endIndex);
                    Console.WriteLine(activationKey);
                }
                else if (cmdType == "Slice")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    activationKey = Slice(activationKey, startIndex, endIndex);
                    Console.WriteLine(activationKey);
                }
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        static string Slice(string activationKey, int startIndex, int endIndex)
        {
            activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
            return activationKey;
        }

        static string Flip(string activationKey, string casing, int startIndex, int endIndex)
        {
            string newSubString = activationKey.Substring(startIndex, endIndex - startIndex);
            if (casing == "Upper")
            {
                newSubString = newSubString.ToUpper();
            }
            else if (casing == "Lower")
            {
                newSubString = newSubString.ToLower();
            }

            activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
            activationKey = activationKey.Insert(startIndex, newSubString);

            return activationKey;
        }

        static void Contains(string activationKey, string subString)
        {
            if (!activationKey.Contains(subString))
            {
                Console.WriteLine("Substring not found!");
                return;
            }
            Console.WriteLine($"{activationKey} contains {subString}");
        }
    }
}
