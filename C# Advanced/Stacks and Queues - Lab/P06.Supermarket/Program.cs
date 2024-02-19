namespace P06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string name;
            while ((name = Console.ReadLine()) != "End")
            {
                if (name == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(name);
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
