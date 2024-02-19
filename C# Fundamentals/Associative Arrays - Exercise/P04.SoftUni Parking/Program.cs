namespace P04.SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingInfo = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string username = cmdArgs[1];

                if (cmdType == "register")
                {
                    string licensePlateNumber = cmdArgs[2];

                    if (parkingInfo.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingInfo[username]}");
                        continue;
                    }

                    parkingInfo[username] = licensePlateNumber;
                    Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                }
                else if (cmdType == "unregister")
                {
                    if (!parkingInfo.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                        continue;
                    }

                    parkingInfo.Remove(username);
                    Console.WriteLine($"{username} unregistered successfully");
                }
            }
            foreach (var item in parkingInfo)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
