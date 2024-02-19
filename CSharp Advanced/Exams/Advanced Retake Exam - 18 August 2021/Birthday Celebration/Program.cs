namespace Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guestsEatingCapacity = Console.ReadLine()
     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
     .Select(int.Parse)
     .ToArray();

            int[] foodQuantities = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            Queue<int> guests = new Queue<int>(guestsEatingCapacity);
            Stack<int> food = new Stack<int>(foodQuantities);

            int wastedFood = 0;

            while (guests.Count > 0 && food.Count > 0)
            {
                int guestCapacity = guests.Dequeue();
                int foodQty = food.Pop();

                if (guestCapacity > foodQty)
                {
                    guestCapacity -= foodQty;
                    guests.Enqueue(guestCapacity);

                    for (int i = 0; i < guests.Count - 1; i++)
                    {
                        guests.Enqueue(guests.Dequeue());
                    }
                }
                else if (guestCapacity < foodQty)
                {
                    wastedFood += foodQty - guestCapacity;
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(' ', food)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
