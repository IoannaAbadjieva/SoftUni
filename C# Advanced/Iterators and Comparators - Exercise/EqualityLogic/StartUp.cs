using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashset = new HashSet<Person>();
            SortedSet<Person> sortedset = new SortedSet<Person>();

            int count =int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person newPerson = new Person(personInfo[0], int.Parse(personInfo[1]));

                hashset.Add(newPerson);
                sortedset.Add(newPerson);
            }

            Console.WriteLine(hashset.Count);
            Console.WriteLine(sortedset.Count);
        }
    }
}
