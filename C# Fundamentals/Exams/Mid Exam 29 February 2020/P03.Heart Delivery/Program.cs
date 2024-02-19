namespace P03.Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command;
            int houseIndex = 0;
            int counter = 0;

            while ((command = Console.ReadLine()) != "Love!")
            {
                int jumpLenght = int.Parse(command.Substring(4));

                houseIndex += jumpLenght;

                if (!IsIndexValid(neighborhood, houseIndex))
                {
                    houseIndex = 0;
                }

                neighborhood[houseIndex] -= 2;

                if (neighborhood[houseIndex] == -2)
                {
                    Console.WriteLine($"Place {houseIndex} already had Valentine's day.");
                    neighborhood[houseIndex] = 0;
                }
                else if (neighborhood[houseIndex] == 0)
                {
                    Console.WriteLine($"Place {houseIndex} has Valentine's day.");
                    counter++;
                }
            }

            Console.WriteLine($"Cupid's last position was {houseIndex}.");

            if (counter == neighborhood.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {neighborhood.Length - counter} places.");
            }
        }

        static bool IsIndexValid(int[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }
    }
}
