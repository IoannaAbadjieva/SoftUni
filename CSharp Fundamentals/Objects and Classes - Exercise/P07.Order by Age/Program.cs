namespace P07.Order_by_Age
{
    class Person
    {
        public Person(string name, string ID, int age)
        {
            this.Name = name;
            this.ID = ID;
            this.Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public void UpdatePersonData(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                string ID = personInfo[1];
                int age = int.Parse(personInfo[2]);

                Person searchedPerson = persons.FirstOrDefault(x => x.ID == ID);
                if (searchedPerson != null)
                {
                    searchedPerson.UpdatePersonData(name, age);
                    continue;
                }

                Person newPerson = new Person(name, ID, age);
                persons.Add(newPerson);
            }

            persons
                .OrderBy(x => x.Age).ToList()
                .ForEach(x => Console.WriteLine(x));

        }
    }
}
