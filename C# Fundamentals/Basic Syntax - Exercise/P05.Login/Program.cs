namespace P05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string reversed = string.Empty;

            for (int i = user.Length - 1; i >= 0; i--)
            {
                reversed += user[i];
            }

            int counter = 0;

            string password = Console.ReadLine();
            while (password != reversed)
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine($"User {user} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
            }
            Console.WriteLine($"User {user} logged in.");
        }
    }
}
