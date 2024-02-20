namespace CollectionHierarchy.Models
{
    using Contracts;
    using System.Linq;

    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public AddRemoveCollection()
            : base()
        {

        }

        public override int Add(string value)
        {
            this.Strings.Insert(0, value);
            return 0;
        }

        public virtual string Remove()
        {
            string removedItem = this.Strings.Last();
            this.Strings.RemoveAt(strings.Count - 1);

            return removedItem;
        }
    }
}
