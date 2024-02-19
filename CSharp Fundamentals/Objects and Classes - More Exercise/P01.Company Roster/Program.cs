namespace P01.Company_Roster
{
    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }

        public double Salary { get; set; }

        public string Department { get; set; }

        public override string ToString() => $"{Name} {Salary:f2}";

    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] employeeInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = employeeInfo[0];
                double salary = double.Parse(employeeInfo[1]);
                string department = employeeInfo[2];

                if (!departments.Contains(department))
                {
                    departments.Add(department);
                }

                Employee newEmployee = new Employee(name, salary, department);
                employees.Add(newEmployee);
            }

            string bestDepartment = GetBestDepartment(employees, departments);

            List<Employee> filteredEmployees = employees
                .Where(x => x.Department == bestDepartment)
                .OrderByDescending(x => x.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            filteredEmployees.ForEach(x => Console.WriteLine(x));
        }

        static string GetBestDepartment(List<Employee> employees, List<string> departments)
        {
            double maxSalary = 0;
            string bestDepartment = string.Empty;

            for (int i = 0; i < departments.Count; i++)
            {
                string currDepartment = departments[i];
                double currDepAvgSalary = employees
                    .Where(x => x.Department == currDepartment)
                    .Average(x => x.Salary);

                if (currDepAvgSalary > maxSalary)
                {
                    maxSalary = currDepAvgSalary;
                    bestDepartment = currDepartment;
                }
            }

            return bestDepartment;
        }
    }
}
