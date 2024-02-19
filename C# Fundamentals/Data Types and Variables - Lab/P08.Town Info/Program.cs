namespace P08.Town_Info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            uint population = uint.Parse(Console.ReadLine());
            ushort area = ushort.Parse(Console.ReadLine());

            Console.WriteLine($"Town {name} has population of {population} and area {area} square km.");
        }
    }
}
