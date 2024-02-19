namespace P08.Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();

            if (parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> stack = new Stack<char>();

            bool isBalanced = true;
            for (int i = 0; i < parentheses.Length; i++)
            {
                char currChar = parentheses[i];
                if (currChar == '(' || currChar == '[' || currChar == '{')
                {
                    stack.Push(currChar);
                }
                else
                {
                    if (currChar == ')')
                    {
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else if (currChar == ']')
                    {
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else if (currChar == '}')
                    {
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }
            }

            if (isBalanced && stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
