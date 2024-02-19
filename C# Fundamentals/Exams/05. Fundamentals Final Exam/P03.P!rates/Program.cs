namespace P03.P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<long>> cities = new Dictionary<string, List<long>>();

            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] cityInfo = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                AddCityInfo(cityInfo, cities);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string city = cmdArgs[1];

                if (!cities.ContainsKey(city))
                {
                    continue;
                }

                if (cmdType == "Plunder")
                {
                    long people = long.Parse(cmdArgs[2]);
                    long gold = long.Parse(cmdArgs[3]);
                    Plunder(cities, city, people, gold);
                    if (IsCityDisbanded(cities, city))
                    {
                        DisbandCity(cities, city);
                    }
                }
                else if (cmdType == "Prosper")
                {
                    long gold = long.Parse(cmdArgs[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    Prosper(cities, city, gold);
                }
            }
            PrintTargetsInfo(cities);
        }

        static void AddCityInfo(string[] cityInfo, Dictionary<string, List<long>> cities)
        {
            string cityName = cityInfo[0];
            int population = int.Parse(cityInfo[1]);
            int gold = int.Parse(cityInfo[2]);

            if (!cities.ContainsKey(cityName))
            {
                cities[cityName] = new List<long>();
                cities[cityName].Add(population);
                cities[cityName].Add(gold);
            }
            else
            {
                cities[cityName][0] += population;
                cities[cityName][1] += gold;
            }
        }

        static void Plunder(Dictionary<string, List<long>> cities, string city, long people, long gold)
        {
            long population = cities[city][0];
            if (population < people)
            {
                people = population;
            }
            cities[city][0] -= people;

            long trasury = cities[city][1];
            if (trasury < gold)
            {
                gold = trasury;
            }
            cities[city][1] -= gold;

            Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");
        }

        static bool IsCityDisbanded(Dictionary<string, List<long>> cities, string city)
        {
            return cities[city][0] <= 0 || cities[city][1] <= 0;
        }

        static void DisbandCity(Dictionary<string, List<long>> cities, string city)
        {
            cities.Remove(city);
            Console.WriteLine($"{city} has been wiped off the map!");
        }

        static void Prosper(Dictionary<string, List<long>> cities, string city, long gold)
        {
            cities[city][1] += gold;
            Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city][1]} gold.");
        }

        static void PrintTargetsInfo(Dictionary<string, List<long>> cities)
        {
            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                return;
            }

            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
            }
        }
    }
}
