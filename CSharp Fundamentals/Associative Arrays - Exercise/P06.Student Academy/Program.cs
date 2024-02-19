namespace P06.Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string studentname = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentname))
                {
                    students[studentname] = new List<double>();
                }
                students[studentname].Add(grade);
            }


            foreach (var item in students)
            {
                if (item.Value.Average() < 4.50)
                {
                    students.Remove(item.Key);
                }
            }

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
