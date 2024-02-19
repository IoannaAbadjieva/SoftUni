namespace P02.Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int treated = 0;
            int untreated = 0;
            int doctors = 7;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i % 3 == 0 && untreated > treated)
                {
                    doctors++;
                }

                if (num < doctors)
                {
                    treated += num;
                }
                else
                {
                    treated += doctors;
                    untreated += num - doctors;
                }
            }
            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");

        }
    }
}
