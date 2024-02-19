namespace P02.The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            const int capacity = 4;

            int[] lift = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int index = 0;

            while (people >= 0 && index < lift.Length)
            {
                int freeSeats = capacity - lift[index];

                if (people >= freeSeats)
                {
                    lift[index] = capacity;
                }
                else
                {
                    lift[index] += people;
                }

                people -= freeSeats;
                index++;
            }

            if (people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
            }
            else if (people < 0)
            {
                Console.WriteLine("The lift has empty spots!");
            }

            Console.WriteLine(string.Join(' ', lift));
        }
    }
}
