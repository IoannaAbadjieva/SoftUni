namespace P04.Students
{
    class Student
    {
        public Student(string firstName, string lastname, double grade)
        {
            FirstName = firstName;
            LastName = lastname;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString() => $"{this.FirstName} {this.LastName}: {this.Grade:f2}";

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] studentArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentArgs[0];
                string lastName = studentArgs[1];
                double grade = double.Parse(studentArgs[2]);

                Student newStudent = new Student(firstName, lastName, grade);
                students.Add(newStudent);
            }


            students
                .OrderByDescending(x => x.Grade).ToList()
                .ForEach(x => Console.WriteLine(x));

        }
    }
}
