namespace P01.Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            string input = Console.ReadLine();
            int counter = 0;

            while (input != "No More Books" && input != favoriteBook)
            {
                counter++;
                input = Console.ReadLine();
            }
            if (input == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
            else
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
