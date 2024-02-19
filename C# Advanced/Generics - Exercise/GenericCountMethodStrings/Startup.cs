using System;

namespace GenericCountMethodStrings
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string item = Console.ReadLine();
                box.Items.Add(item);
            }

            string itemToCompareWith = Console.ReadLine();

            Console.WriteLine(box.GetCount(itemToCompareWith));
        }
    }
}
