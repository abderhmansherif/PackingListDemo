using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Exceptions
{
    public class AlreadyPackedPackingItemException: PackingListException
    {
        public AlreadyPackedPackingItemException(string ItemName): base($"Packing item with name {ItemName} is already packed.")
        {
        }
    }
}
