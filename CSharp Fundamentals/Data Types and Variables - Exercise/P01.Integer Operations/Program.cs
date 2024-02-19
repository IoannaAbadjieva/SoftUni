namespace P01.Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());

            long firstOperation = (long)first + second;
            long secondOperation = firstOperation / third;
            long thirdOperation = secondOperation * fourth;

            Console.WriteLine(thirdOperation);
        }
    }
}
