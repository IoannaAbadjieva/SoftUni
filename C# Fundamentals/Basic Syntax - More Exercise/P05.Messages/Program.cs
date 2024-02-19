namespace P05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string message = string.Empty;
            int offset;
            int main;

            while (input != string.Empty)
            {
                main = int.Parse(input[0].ToString());

                if (main == 0)
                {
                    message += (char)32;
                    input = Console.ReadLine();
                    continue;
                }
                if (main == 8 || main == 9)
                {
                    offset = (main - 2) * 3 + 1;
                }
                else
                {
                    offset = (main - 2) * 3;
                }
                message += (char)(offset + input.Length - 1 + 97);
                input = Console.ReadLine();
            }
            Console.WriteLine(message);

        }
    }
}
