using System.Text;

namespace P09.Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            stack.Push(string.Empty);

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "1")
                {
                    string textToAdd = cmdArgs[1];
                    sb.Append(textToAdd);
                    stack.Push(sb.ToString());
                }
                else if (cmdType == "2")
                {
                    int count = int.Parse(cmdArgs[1]);
                    sb.Remove(sb.Length - count, count);
                    stack.Push(sb.ToString());
                }
                else if (cmdType == "3")
                {
                    int position = int.Parse(cmdArgs[1]);
                    if (position > 0 && position <= sb.Length)
                    {
                        Console.WriteLine(sb[position - 1]);
                    }
                }
                else if (cmdType == "4")
                {
                    stack.Pop();
                    sb = new StringBuilder(stack.Peek());
                }
            }
        }
    }
}
