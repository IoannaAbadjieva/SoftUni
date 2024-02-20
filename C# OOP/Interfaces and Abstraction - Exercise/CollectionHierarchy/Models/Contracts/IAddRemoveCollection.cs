namespace CollectionHierarchy.Models.Contracts
{
    using System.Collections.Generic;

    public interface IAddRemoveCollection : IAddCollection
    {
       
        string Remove();

    }
}
