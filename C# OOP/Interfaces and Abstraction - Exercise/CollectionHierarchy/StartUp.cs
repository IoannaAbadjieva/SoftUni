namespace CollectionHierarchy
{
    using System;
    using System.Collections.Generic;

    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection removeCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> addCollectiongResults = new List<int>();
            List<int> removeCollectionAddResults = new List<int>();
            List<string> removeCollectionRemoveResults = new List<string>();
            List<int> MyListAddResults = new List<int>();
            List<string> MyListRemoveResults = new List<string>();

            string[]input = Console.ReadLine().Split(' ');
            int count = int.Parse(Console.ReadLine());

            foreach (string item in input)
            {
                addCollectiongResults.Add(addCollection.Add(item));
                removeCollectionAddResults.Add(removeCollection.Add(item));
                MyListAddResults.Add(myList.Add(item));
            }

            for (int i = 0; i < count; i++)
            {
                removeCollectionRemoveResults.Add(removeCollection.Remove());
                MyListRemoveResults.Add(myList.Remove());
            }

            Console.WriteLine(String.Join(" ",addCollectiongResults));
            Console.WriteLine(String.Join(" ",removeCollectionAddResults));
            Console.WriteLine(String.Join(" ",MyListAddResults));
            Console.WriteLine(String.Join(" ",removeCollectionRemoveResults));
            Console.WriteLine(String.Join(" ",MyListRemoveResults));
        }
    }
}
