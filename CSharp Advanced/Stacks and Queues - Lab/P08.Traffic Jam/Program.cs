namespace P08.Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            string model;
            int carsPassed = 0;
            while ((model = Console.ReadLine()) != "end")
            {
                if (model != "green")
                {
                    queue.Enqueue(model);
                    continue;
                }

                int carsToPass = Math.Min(n, queue.Count);
                for (int i = 0; i < carsToPass; i++)
                {
                    Console.WriteLine($"{queue.Dequeue()} passed!");
                    carsPassed++;
                }
            }
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
