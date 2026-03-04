using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Exceptions
{
    public class EmptyPackingListItemNameException: PackingListException
    {
        public EmptyPackingListItemNameException(): base("Packing list item name cannot be empty.")
        {
        }
    }
}
