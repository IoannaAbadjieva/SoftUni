using System.Text;

namespace P02.Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(' ');
            StringBuilder sb = new StringBuilder();

            foreach (string word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    sb.Append(word);
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
