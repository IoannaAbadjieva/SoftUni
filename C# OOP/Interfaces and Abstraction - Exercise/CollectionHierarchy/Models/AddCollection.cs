namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class AddCollection : IAddCollection
    {
        protected List<string> strings;

        public AddCollection()
        {
            this.Strings = new List<string>();
        }

        public List<string> Strings { get; private set; }

        public virtual int Add(string value)
        {
            strings.Add(value);
            return strings.Count - 1;
        }
    }
}
