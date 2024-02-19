namespace The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int wavesCount = int.Parse(Console.ReadLine());

                int[] defensePlates = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Queue<int> plates = new Queue<int>(defensePlates);

                for (int i = 1; i <= wavesCount; i++)
                {
                    int[] orcsWave = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                    if (i % 3 == 0)
                    {
                        plates.Enqueue(int.Parse(Console.ReadLine()));
                    }

                    Stack<int> orcs = new Stack<int>(orcsWave);

                    while (plates.Count > 0 && orcs.Count > 0)
                    {
                        int plateStrenght = plates.Dequeue();
                        int orcStrenght = orcs.Pop();

                        if (orcStrenght > plateStrenght)
                        {
                            orcs.Push(orcStrenght - plateStrenght);
                        }
                        else if (orcStrenght < plateStrenght)
                        {
                            plates.Enqueue(plateStrenght - orcStrenght);

                            for (int j = 0; j < plates.Count - 1; j++)
                            {
                                plates.Enqueue(plates.Dequeue());
                            }
                        }
                    }

                    if (plates.Count == 0)
                    {
                        Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                        Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                        return;
                    }
                }

                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
