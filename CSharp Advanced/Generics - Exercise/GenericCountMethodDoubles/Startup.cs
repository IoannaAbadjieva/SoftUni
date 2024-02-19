using System;

namespace GenericCountMethodDoubles
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double item = double.Parse(Console.ReadLine());
                box.Items.Add(item);
            }

            double itemToCompareWith = double.Parse(Console.ReadLine());

            Console.WriteLine(box.GetCount(itemToCompareWith));
        }
    }
   
}
