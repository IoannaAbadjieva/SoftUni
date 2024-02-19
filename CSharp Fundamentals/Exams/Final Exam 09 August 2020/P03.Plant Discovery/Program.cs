namespace P03.Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Plant> plants = new List<Plant>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int rarity = int.Parse(input[1]);

                Plant searchedPlant = plants.FirstOrDefault(x => x.Name == name);
                if (searchedPlant == null)
                {
                    Plant newPlant = new Plant(name, rarity);
                    plants.Add(newPlant);
                }
                else
                {
                    searchedPlant.UpdateRarity(rarity);
                }

            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] cmdArgs = command
                    .Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string name = cmdArgs[1];

                if (!plants.Any(x => x.Name == name))
                {
                    Console.WriteLine("error");
                    continue;
                }

                Plant plant = plants.FirstOrDefault(x => x.Name == name);

                if (cmdType == "Rate")
                {
                    int rating = int.Parse(cmdArgs[2]);
                    plant.Rate.Add(rating);
                }
                else if (cmdType == "Update")
                {
                    int newRarity = int.Parse(cmdArgs[2]);
                    plant.UpdateRarity(newRarity);
                }
                else if (cmdType == "Reset")
                {
                    plant.Rate.Clear();
                }
            }
            PrintPlantsForExhibition(plants);
        }

        private static void PrintPlantsForExhibition(List<Plant> plants)
        {
            Console.WriteLine("Plants for the exhibition:");

            foreach (Plant plant in plants)
            {
                Console.WriteLine(plant);
            }
        }
    }

    class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Rate = new List<int>();
        }

        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<int> Rate { get; set; }

        public void UpdateRarity(int newRarity)
        {
            Rarity = newRarity;
        }

        public override string ToString()
        {

            return $"- {Name}; Rarity: {Rarity}; Rating: {(Rate.Count > 0 ? Rate.Average() : 0):f2}";
        }
    }
}
