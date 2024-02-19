using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public int Count { get { return list.Count; } }

        public void Add(T element)
        {
            list.Add(element);
        }

        public T Remove()
        {
            T elementToRemove = list.Last();
            list.RemoveAt(list.Count -1);
            return elementToRemove;
        }

    }
}
