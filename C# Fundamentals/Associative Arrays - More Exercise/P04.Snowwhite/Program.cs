namespace P04.Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] dwarfInfo = input
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string dwarfType = $"({dwarfInfo[1]}) {dwarfInfo[0]}";
                int dwarfPhysics = int.Parse(dwarfInfo[2]);

                if (!dwarfs.ContainsKey(dwarfType))
                {
                    dwarfs[dwarfType] = dwarfPhysics;
                }
                else
                {
                    int currPfysics = dwarfs[dwarfType];
                    dwarfs[dwarfType] = Math.Max(currPfysics, dwarfPhysics);
                }
            }
            PrintDwarfsInfo(dwarfs);
        }

        static void PrintDwarfsInfo(Dictionary<string, int> dwarfs)
        {
            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfs.Where(hatColor => hatColor.Key.Split(' ')[0]
                == x.Key.Split(' ')[0]).Count()))
            {
                Console.WriteLine($"{dwarf.Key} <-> {dwarf.Value}");
            }
        }
    }
}
