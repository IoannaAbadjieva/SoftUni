using System;
using System.Collections.Generic;
using System.Linq;

using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly ICollection<Item> items;
         
        private Bag()
        {
            this.items = new List<Item>();
        }
        protected Bag(int capacity = 100)
            :this()
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>)this.items;

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.Items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);
            return item;
        }
    }
}
