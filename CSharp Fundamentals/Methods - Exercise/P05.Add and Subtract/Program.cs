namespace P05.Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int result = GetDifference(GetSum(num1, num2), num3);
            Console.WriteLine(result);
        }


        static int GetSum(int first, int second)
        {
            return first + second;
        }

        static int GetDifference(int first, int second)
        {
            return first - second;
        }
    }
}
