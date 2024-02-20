using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new RandomList();

            strings.Add("one");
            strings.Add("two");
            strings.Add("three");

            Console.WriteLine(strings.RandomString());
            Console.WriteLine(strings.RandomString());
            Console.WriteLine(strings.RandomString());
        }
    }
}
