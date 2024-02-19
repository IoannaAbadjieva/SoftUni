namespace P07.Safe_Passwords_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());

            char A = (char)35;
            char B = (char)64;
            int passCounter = 0;
            bool isEnd = false;

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    Console.Write($"{A}{B}{x}{y}{B}{A}|");
                    passCounter++;
                    if (passCounter == maxPasswords)
                    {
                        isEnd = true;
                        break;
                    }
                    A++;
                    B++;
                    if (A > 55) A = (char)35;
                    if (B > 96) B = (char)64;
                }
                if (isEnd) break;
            }
        }
    }
}
