namespace P03.House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] guestInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = guestInfo[0];

                if (guestInfo.Length == 3)
                {
                    if (guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }

                    guestList.Add(name);
                }
                else if (guestInfo.Length == 4)
                {
                    if (!guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }

                    guestList.Remove(name);
                }
            }

            PrintElementsOnNewLine(guestList);
        }

        static void PrintElementsOnNewLine(List<string> guestList)
        {
            foreach (var guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
