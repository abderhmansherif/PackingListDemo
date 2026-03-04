using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Exceptions
{
    public class NotFoundPackingListItemException: PackingListException
    {
        public NotFoundPackingListItemException(string name): base($"Packing item with name {name} not found to remove or update.")
        {
        }
    }
}
