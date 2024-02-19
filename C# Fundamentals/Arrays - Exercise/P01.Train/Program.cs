namespace P01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] train = new int[n];
            int passengers = 0;

            for (int index = 0; index < train.Length; index++)
            {
                train[index] = int.Parse(Console.ReadLine());
                passengers += train[index];
            }

            Console.WriteLine(string.Join(' ', train));
            Console.WriteLine(passengers);
        }
    }
}
