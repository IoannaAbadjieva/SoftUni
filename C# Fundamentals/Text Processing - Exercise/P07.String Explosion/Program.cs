using System.Text;

namespace P07.String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int bombsPower = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (currChar == '>')
                {
                    sb.Append(currChar);
                    bombsPower += (int)input[i + 1] - 48;
                }
                else
                {
                    if (bombsPower > 0)
                    {
                        bombsPower--;
                    }
                    else
                    {
                        sb.Append(currChar);
                    }
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
