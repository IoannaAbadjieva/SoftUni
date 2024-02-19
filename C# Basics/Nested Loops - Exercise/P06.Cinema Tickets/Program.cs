namespace P06.Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int studentTicketsCount = 0;
            int standardTicketsCount = 0;
            int kidsTicketsCount = 0;
            int totalTicketsCount = 0;

            while (movie != "Finish")
            {
                int sits = int.Parse(Console.ReadLine());
                int counter = 0;

                string ticket = Console.ReadLine();
                while (ticket != "End")
                {
                    counter++;
                    if (ticket == "student") studentTicketsCount++;
                    else if (ticket == "standard") standardTicketsCount++;
                    else kidsTicketsCount++;
                    if (counter == sits)
                    {
                        break;
                    }
                    ticket = Console.ReadLine();
                }
                Console.WriteLine($"{movie} - {counter * 100.0 / sits:f2}% full.");
                totalTicketsCount += counter;
                movie = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTicketsCount}");
            Console.WriteLine($"{studentTicketsCount * 100.0 / totalTicketsCount:f2}% student tickets.");
            Console.WriteLine($"{standardTicketsCount * 100.0 / totalTicketsCount:f2}% standard tickets.");
            Console.WriteLine($"{kidsTicketsCount * 100.0 / totalTicketsCount:f2}% kids tickets.");
        }
    }
}
