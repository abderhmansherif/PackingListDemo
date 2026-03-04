using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Exceptions
{
    internal class PackingListNotFoundException : PackingListException
    {
        public PackingListNotFoundException(Guid id): base($"Packing list with ID '{id}' was not found.")
        {
        }
    }
}
