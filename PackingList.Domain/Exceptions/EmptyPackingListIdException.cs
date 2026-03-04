using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Exceptions
{
    public class EmptyPackingListIdException: PackingListException
    {
        public EmptyPackingListIdException(): base("Packing list ID cannot be empty.")
        {
        }
    }
}
