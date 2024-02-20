using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random random = new Random();

        public string RandomString()
        {
            if (Count == 0)
            {
                return default;
            }
            int index = random.Next(0, Count);
            string removedItem = this[index];
            RemoveAt(index);
            return removedItem;
        }
    }
}
