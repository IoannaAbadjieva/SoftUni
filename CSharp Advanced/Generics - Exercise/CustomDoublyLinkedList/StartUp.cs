using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> nums = new DoublyLinkedList<int>();
            nums.AddLast(1);
            nums.AddLast(2);
            nums.AddLast(3);
            nums.AddLast(4);

            nums.AddFirst(1);
            nums.AddFirst(2);
            nums.AddFirst(3);
            nums.AddFirst(4);

            nums.ForEach(n => Console.Write($"{n} "));
            Console.WriteLine();

            Console.WriteLine(nums.RemoveFirst());
            Console.WriteLine(nums.RemoveLast());

            int[] array = nums.ToArray();
            Console.WriteLine(String.Join(' ',array));

        }
    }
}
