using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] internalArray;

        public Stack()
        {
            internalArray = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (Count == internalArray.Length)
            {
                Resize();
            }
            internalArray[Count++] = item;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T itemToPop = internalArray[Count - 1];
            internalArray[Count - 1] = default;
            Count--;

            return itemToPop;

        }

        private void Resize()
        {
            T[] newArray = internalArray;

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = internalArray[i];
            }

            internalArray = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return internalArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
