namespace P05.Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<Person, string, int, bool> ageFilter = (p, f, a) => f == "older" ? p.Age >= a : p.Age < a;
            Func<Person, string[], string> printFormat = (p, f) =>
            {
                string formattingString = string.Empty;

                if (f.Length == 2)
                {
                    if (f[0] == "name")
                    {
                        formattingString = "{0} - {1}";
                    }
                    else if (f[0] == "age")
                    {
                        formattingString = "{1} - {0}";
                    }
                }
                else
                {
                    if (f[0] == "name")
                    {
                        formattingString = "{0}";
                    }
                    else if (f[0] == "age")
                    {
                        formattingString = "{1}";
                    }
                }
                return String.Format(formattingString, p.Name, p.Age);
            };

            int n = int.Parse(Console.ReadLine());
            Person[] persons = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                persons[i] = new Person(personInfo[0], int.Parse(personInfo[1]));
            }

            string filter = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(String.Join(Environment.NewLine, persons
                .Where(p => ageFilter(p, filter, age))
                .Select(p => printFormat(p, format))));
        }
    }
}
class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }

    public int Age { get; set; }
}
