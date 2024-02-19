using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>:IEnumerable<T>
    {
        private List<T> list;

        private int index = 0;

        public ListyIterator(List<T> list)
        {
            this.list = list;
        }

        public bool Move()
        {
            if (index + 1 < list.Count)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return index < list.Count -1;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(list[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
