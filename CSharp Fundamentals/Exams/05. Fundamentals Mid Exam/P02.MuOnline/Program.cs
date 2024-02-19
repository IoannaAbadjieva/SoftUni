namespace P02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int health = 100;
            int bitcoins = 0;

            string[] commands = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);


            for (int index = 0; index < commands.Length; index++)
            {
                string currCommand = commands[index];

                string[] cmdArgs = currCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "potion")
                {
                    int amount = int.Parse(cmdArgs[1]);

                    if (health + amount > 100)
                    {
                        amount = 100 - health;
                    }
                    health += amount;

                    Console.WriteLine($"You healed for {amount} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (cmdType == "chest")
                {
                    int amount = int.Parse(cmdArgs[1]);
                    bitcoins += amount;

                    Console.WriteLine($"You found {amount} bitcoins.");
                }
                else
                {
                    string monster = cmdArgs[0];
                    int attack = int.Parse(cmdArgs[1]);

                    health -= attack;

                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {index + 1}");
                        return;
                    }

                    Console.WriteLine($"You slayed {monster}.");
                }

                if (index == commands.Length - 1)
                {
                    Console.WriteLine("You've made it!");
                    Console.WriteLine($"Bitcoins: {bitcoins}");
                    Console.WriteLine($"Health: {health}");
                }
            }
        }
    }
}
