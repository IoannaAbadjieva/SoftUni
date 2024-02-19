namespace P01.Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int a;
            int b;
            int c;

            if (y >= z)
            {
                a = y;
                b = z;
            }
            else
            {
                a = z;
                b = y;
            }
            if (x > a)
            {
                b = a;
                c = b;
                a = x;
            }
            else
            {
                if (x > b)
                {
                    c = b;
                    b = x;
                }
                else
                {
                    c = x;
                }
            }
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}
