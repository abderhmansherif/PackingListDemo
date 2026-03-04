using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Exceptions
{
    public class AlreadyExistsPackingListNameException: PackingListException
    {
        public AlreadyExistsPackingListNameException(string name): base($"Packing list with name: {name} already exists.")
        {
        }
    }
}
