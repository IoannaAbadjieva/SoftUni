using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();

            Console.WriteLine(stackOfStrings.IsEmpty());

            stackOfStrings.AddRange(new string[] { "one", "two", "three" });

            Console.WriteLine(String.Join(Environment.NewLine,stackOfStrings));
        }
    }
}
