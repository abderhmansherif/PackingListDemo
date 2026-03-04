using PackingList.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.ValueObjects
{
    public record PackingListItem
    {
        public string Name { get; }
        public int Quantity { get; }
        public bool IsPacked { get; init; }

        public PackingListItem(string name, int quantity, bool isPacked = false)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new EmptyPackingListItemNameException();
            }

            Name = name;
            Quantity = (quantity <= 0)? 1: quantity;
            IsPacked = isPacked;
        }
    }
}
