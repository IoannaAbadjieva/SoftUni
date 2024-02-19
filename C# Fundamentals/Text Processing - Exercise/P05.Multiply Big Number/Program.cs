using System.Text;

namespace P05.Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            char[] number = Console.ReadLine().ToCharArray();
            Array.Reverse(number);

            int multiplyer = int.Parse(Console.ReadLine());
            int reminder = 0;

            if (multiplyer == 0)
            {
                Console.WriteLine(0);
                return;
            }

            foreach (var ch in number)
            {
                int result = multiplyer * ((int)ch - 48) + reminder;
                reminder = result / 10;
                result %= 10;
                sb.Insert(0, result);
            }

            if (reminder > 0)
            {
                sb.Insert(0, reminder);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
