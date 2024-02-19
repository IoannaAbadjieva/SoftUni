using System;

namespace GenericScale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EqualityScale<string> equalityScale = new EqualityScale<string>("left","Left");
            Console.WriteLine(equalityScale.AreEqual());
        }
    }
}
