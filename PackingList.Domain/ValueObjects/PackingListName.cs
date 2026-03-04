using PackingList.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.ValueObjects
{
    public record PackingListName
    {
        public string Value { get; }

        public PackingListName(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new EmptyPackingListNameException();
            }

            Value = value;
        }

        public static implicit operator string (PackingListName name)
            => name.Value;

        public static implicit operator PackingListName(string name)
            => new PackingListName(name);
    }
}
