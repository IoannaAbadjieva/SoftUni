namespace P03.Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] warShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int healthCapacity = int.Parse(Console.ReadLine());

            string command;

            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "Fire")
                {
                    int indexOnFire = int.Parse(cmdArgs[1]);
                    int damage = int.Parse(cmdArgs[2]);

                    if (!IsIndexValid(warShip, indexOnFire))
                    {
                        continue;
                    }

                    warShip[indexOnFire] -= damage;

                    if (warShip[indexOnFire] <= 0)
                    {
                        Console.WriteLine("You won! The enemy ship has sunken.");
                        return;
                    }
                }
                else if (cmdType == "Defend")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    int damage = int.Parse(cmdArgs[3]);

                    if (!IsIndexValid(pirateShip, startIndex) || !IsIndexValid(pirateShip, endIndex))
                    {
                        continue;
                    }

                    for (int index = startIndex; index <= endIndex; index++)
                    {
                        pirateShip[index] -= damage;

                        if (pirateShip[index] <= 0)
                        {
                            Console.WriteLine("You lost! The pirate ship has sunken.");
                            return;
                        }
                    }
                }
                else if (cmdType == "Repair")
                {
                    int indexToRepair = int.Parse(cmdArgs[1]);
                    int health = int.Parse(cmdArgs[2]);


                    if (!IsIndexValid(pirateShip, indexToRepair))
                    {
                        continue;
                    }

                    pirateShip[indexToRepair] += health;

                    if (pirateShip[indexToRepair] > healthCapacity)
                    {
                        pirateShip[indexToRepair] = healthCapacity;
                    }
                }
                else if (cmdType == "Status")
                {
                    int count = GetHealtOfShipStatus(pirateShip, healthCapacity);
                    Console.WriteLine($"{count} sections need repair.");
                }
            }

            int pirateShipStatus = GetShipStatus(pirateShip);
            int warShipStatus = GetShipStatus(warShip);

            Console.WriteLine($"Pirate ship status: {pirateShipStatus}");
            Console.WriteLine($"Warship status: {warShipStatus}");


        }

        static bool IsIndexValid(int[] arr, int index)
        {
            return index >= 0 && index < arr.Length;
        }

        static int GetHealtOfShipStatus(int[] arr, int capacity)
        {
            int sectionsToRepairCount = 0;
            double repairValue = capacity * 0.20;

            for (int index = 0; index < arr.Length; index++)
            {
                int currSectionStatus = arr[index];

                if (currSectionStatus < repairValue)
                {
                    sectionsToRepairCount++;
                }
            }

            return sectionsToRepairCount;
        }

        static int GetShipStatus(int[] ship)
        {
            int shipSum = 0;

            foreach (var section in ship)
            {
                shipSum += section;
            }

            return shipSum;
        }
    }
}
