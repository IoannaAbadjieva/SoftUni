using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string person;
            while ((person = Console.ReadLine()) != "END")
            {
                string[] personInfo = person.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person newPerson = new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]);
                persons.Add(newPerson);
            }
            int position = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = persons[position];
            int equalsCount = 0;
            int differsCount = 0;

            foreach (Person other in persons)
            {
                if (other.CompareTo(personToCompare) == 0)
                {
                    equalsCount++;
                }
                else
                {
                    differsCount++;
                }
            }

            if (equalsCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalsCount} {differsCount} {persons.Count}");
            }
        }
    }
}
