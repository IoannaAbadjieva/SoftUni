namespace P05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] courseInfo = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string course = courseInfo[0];
                string student = courseInfo[1];

                if (!courses.ContainsKey(course))
                {
                    courses[course] = new List<string>();
                }
                courses[course].Add(student);
            }
            PrintCoursesInfo(courses);
        }

        static void PrintCoursesInfo(Dictionary<string, List<string>> courses)
        {
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                item.Value.ForEach(x => Console.WriteLine($"-- {x}"));
            }
        }
    }
}
