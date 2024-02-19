namespace P06.Wedding_Seats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());
            int seatsCount;
            int seatsTotalCount = 0;


            for (char i = 'A'; i <= sector; i++)
            {

                for (int row = 1; row <= rowsCount; row++)
                {
                    seatsCount = seats;
                    if (row % 2 == 0)
                    {
                        seatsCount = seats + 2;
                    }
                    for (char j = 'a'; j < 'a' + seatsCount; j++)
                    {
                        Console.WriteLine($"{i}{row}{j}");
                        seatsTotalCount++;
                    }

                }
                rowsCount++;
            }
            Console.WriteLine(seatsTotalCount);
        }
    }
}
