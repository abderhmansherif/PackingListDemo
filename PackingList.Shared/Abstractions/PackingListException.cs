using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Shared.Abstractions
{
    public abstract class PackingListException: Exception
    {
        protected PackingListException(string message): base(message)
        {
        }

    }
}
