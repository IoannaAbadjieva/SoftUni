namespace P06.Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int seats;
            string type;
            int student;
            int standard;
            int kid;
            int tickets;
            int totalTickets = 0;
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;

            while (movie != "Finish")
            {
                seats = int.Parse(Console.ReadLine());

                student = 0;
                standard = 0;
                kid = 0;
                tickets = 0;
                type = Console.ReadLine();
                while (type != "End")
                {
                    if (type == "student") student++;
                    else if (type == "standard") standard++;
                    else kid++;

                    tickets++;
                    if (tickets == seats)
                    {
                        break;
                    }
                    type = Console.ReadLine();
                }
                studentTickets += student;
                standardTickets += standard;
                kidTickets += kid;
                totalTickets += tickets;
                Console.WriteLine($"{movie} - {tickets * 100.0 / seats:f2}% full.");
                movie = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentTickets * 100.0 / totalTickets:f2}% student tickets.");
            Console.WriteLine($"{standardTickets * 100.0 / totalTickets:f2}% standard tickets.");
            Console.WriteLine($"{kidTickets * 100.0 / totalTickets:f2}% kids tickets.");
        }
    }
}
