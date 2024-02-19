namespace P03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling(countOfPeople * 1.0 / capacity);

            Console.WriteLine(courses);
        }
    }
}
