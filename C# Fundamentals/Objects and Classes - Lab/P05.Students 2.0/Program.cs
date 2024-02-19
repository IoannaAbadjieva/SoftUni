namespace P05.Students_2._0
{
    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Hometown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] studentInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                string hometown = studentInfo[3];

                if (IsStudentExisting(students, firstName, lastName))
                {
                    Student student = students.Find(x => x.FirstName == firstName && x.LastName == lastName);
                    student.Age = age;
                    student.Hometown = hometown;
                    continue;
                }

                Student currentStudent = new Student(firstName, lastName, age, hometown);
                students.Add(currentStudent);
            }

            string city = Console.ReadLine();
            PrintFilteredStudentsList(students, city);
        }

        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }

        static void PrintFilteredStudentsList(List<Student> students, string city)
        {
            List<Student> filteredList = students.FindAll(x => x.Hometown == city);

            foreach (var student in filteredList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
