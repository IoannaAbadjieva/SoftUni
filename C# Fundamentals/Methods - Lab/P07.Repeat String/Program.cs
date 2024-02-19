using System.Text;

namespace P07.Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringToRepeat = Console.ReadLine();
            int repeatTimes = int.Parse(Console.ReadLine());

            string result = RepeatString(stringToRepeat, repeatTimes);
            Console.WriteLine(result);
        }

        static string RepeatString(string str, int count)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }
    }
}
