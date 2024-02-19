namespace P03.Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);

                if (stack.Count == 3)
                {
                    int secondOperand = int.Parse(stack.Pop());
                    string @operator = stack.Pop();
                    int firstOperand = int.Parse(stack.Pop());

                    int result = firstOperand;

                    if (@operator == "+")
                    {
                        result += secondOperand;
                    }
                    else
                    {
                        result -= secondOperand;
                    }

                    stack.Push(result.ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
