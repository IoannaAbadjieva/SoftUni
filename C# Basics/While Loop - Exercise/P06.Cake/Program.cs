namespace P06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int cakePieces = a * b;
            string input = "";

            while (cakePieces > 0)
            {
                input = (Console.ReadLine());
                if (input == "STOP")
                {
                    break;
                }
                cakePieces -= int.Parse(input); ;
            }
            if (cakePieces >= 0)
            {
                Console.WriteLine($"{cakePieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakePieces)} pieces more.");
            }
        }
    }
}
