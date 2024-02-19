namespace P05.Dragon_Army
{
    class Dragon
    {
        public Dragon(string name, int damage, int healt, int armor)
        {
            Name = name;
            Damage = damage;
            Healt = healt;
            Armor = armor;
        }

        public void OverwriteDragon(int damage, int healt, int armor)
        {
            Damage = damage;
            Healt = healt;
            Armor = armor;
        }

        public string Name { get; set; }

        public int Damage { get; set; }

        public int Healt { get; set; }

        public int Armor { get; set; }

        public override string ToString()
        {
            return $"-{Name} -> damage: {Damage}, health: {Healt}, armor: {Armor}";
        }
    }
    class Program
    {
        const int DefaultDamage = 45;
        const int DefaultHealt = 250;
        const int DefaultArmor = 10;


        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] dragonInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = dragonInfo[0];
                string name = dragonInfo[1];
                int damage = int.TryParse(dragonInfo[2], out int dmg) ? dmg : DefaultDamage;
                int health = int.TryParse(dragonInfo[3], out int hlt) ? hlt : DefaultHealt;
                int armor = int.TryParse(dragonInfo[4], out int arm) ? arm : DefaultArmor;

                if (!dragons.ContainsKey(type))
                {
                    dragons[type] = new List<Dragon>();
                    Dragon newDragon = new Dragon(name, damage, health, armor);
                    dragons[type].Add(newDragon);
                }
                else
                {
                    Dragon currDragon = dragons[type].FirstOrDefault(x => x.Name == name);
                    if (currDragon == null)
                    {
                        Dragon newDragon = new Dragon(name, damage, health, armor);
                        dragons[type].Add(newDragon);
                    }
                    else
                    {
                        currDragon.OverwriteDragon(damage, health, armor);
                    }
                }
            }

            PrintDragons(dragons);
        }

        static void PrintDragons(Dictionary<string, List<Dragon>> dragons)
        {
            foreach (var type in dragons)
            {
                Console.WriteLine($"{type.Key}::({type.Value.Average(x => x.Damage):f2}/" +
                    $"{type.Value.Average(x => x.Healt):f2}/" +
                    $"{type.Value.Average(x => x.Armor):f2})");

                foreach (var dragon in type.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine(dragon);
                }
            }
        }
    }
}

