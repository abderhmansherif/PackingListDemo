using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Exceptions
{
    public class AlreadyExistPackingItemException: PackingListException
    {
        public AlreadyExistPackingItemException(string name): base($"Packing item with name {name} already exist.")
        {
        }
    }
}
