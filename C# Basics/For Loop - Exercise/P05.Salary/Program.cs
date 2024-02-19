namespace P05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            int penalty = 0;

            for (int i = 1; i <= n; i++)
            {
                string site = Console.ReadLine();
                switch (site)
                {
                    case "Facebook":
                        penalty += 150;
                        break;
                    case "Instagram":
                        penalty += 100;
                        break;
                    case "Reddit":
                        penalty += 50;
                        break;
                }
                if (penalty >= salary)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (salary > penalty)
            {
                Console.WriteLine(salary - penalty);
            }

        }
    }
}
