namespace P01.Change_Bureau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double CNY = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());

            double euro = (bitcoins * 1168 + CNY * 0.15 * 1.76) / 1.95;
            euro -= euro * comission / 100;
            Console.WriteLine("{0:f2}", euro);
        }
    }
}
