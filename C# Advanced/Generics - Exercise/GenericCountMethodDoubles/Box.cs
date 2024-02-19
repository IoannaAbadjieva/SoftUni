using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Items = new List<T>();
        }

        public List<T> Items  { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().TrimEnd();
        }

        public void Swap(int firstIndex,int secondIndex)
        {
            T temp = Items[firstIndex];
            Items[firstIndex] = Items[secondIndex];
            Items[secondIndex] = temp;
        }

        public int GetCount(T itemToCompareWith)
        {
            int count = 0;

            foreach (T item in Items)
            {
                if (item.CompareTo(itemToCompareWith) > 0)
                {
                    count++;
                }
            }

            return count;
        }


    }
}
