namespace P02.Oldest_Family_Member
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    class Family
    {
        public Family()
        {
            Persons = new List<Person>();
        }

        public List<Person> Persons { get; set; }

        public void AddMembers(Person member)
        {
            Persons.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = Persons.Max(x => x.Age);

            Person searchedPerson = Persons
                .FirstOrDefault(x => x.Age == maxAge);

            return searchedPerson;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family newFamily = new Family();

            for (int i = 1; i <= n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person newPerson = new Person(name, age);
                newFamily.AddMembers(newPerson);
            }
            Person oldestMember = newFamily.GetOldestMember();
            Console.WriteLine(oldestMember);
        }
    }
}
