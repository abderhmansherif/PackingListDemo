using PackingList.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.ValueObjects
{
    public class PackingListId
    {
        public Guid Value { get; }

        public PackingListId(Guid value)
        {
            if(string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyPackingListIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(PackingListId id)
            => id.Value;

        public static implicit operator PackingListId(Guid id)
            => new PackingListId(id);
    }
}
