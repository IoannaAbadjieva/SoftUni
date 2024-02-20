namespace CollectionHierarchy.Models
{
    using Contracts;
    using System.Linq;

    public class MyList : AddRemoveCollection, IMyList
    {
        public MyList()
            :base()
        {

        }

       
        public int Used { get { return this.strings.Count; } }

        public override string Remove()
        {
            string removedItem = this.Strings.First();
            strings.RemoveAt(0);

            return removedItem;
        }
    }
}
