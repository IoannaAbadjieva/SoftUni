using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person newPerson = new Person(name, age);
                persons.Add(newPerson);

            }

            List<Person> filteredPersons = persons
                 .Where(p => p.Age > 30)
                 .OrderBy(p => p.Name)
                 .ToList();

            foreach (Person person in filteredPersons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
