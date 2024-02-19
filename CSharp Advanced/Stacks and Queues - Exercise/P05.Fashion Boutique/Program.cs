namespace P05.Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);

            int racksCount = 0;
            int currRack = 0;

            while (stack.Count > 0)
            {
                if (currRack + stack.Peek() < rackCapacity)
                {
                    currRack += stack.Pop();
                    if (stack.Count == 0)
                    {
                        racksCount++;
                    }
                }
                else if (currRack + stack.Peek() == rackCapacity)
                {
                    currRack += stack.Pop();
                    racksCount++;
                    currRack = 0;
                }
                else
                {
                    racksCount++;
                    currRack = 0;
                }

            }
            Console.WriteLine(racksCount);
        }
    }
}
