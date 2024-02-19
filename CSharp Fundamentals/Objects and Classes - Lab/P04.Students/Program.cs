namespace P04.Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

        public Student(string firstName, string lastName, int age, string hometown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Hometown = hometown;
        }
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

                Student currentStudent = new Student(firstName, lastName, age, hometown);
                students.Add(currentStudent);
            }

            string city = Console.ReadLine();
            PrintFilteredStudentsList(students, city);
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
