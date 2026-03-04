using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Exceptions
{
    public class EmptyPackingListNameException: PackingListException
    {
        public EmptyPackingListNameException(): base("Packing list name cannot be empty.")
        { }
    }
}
