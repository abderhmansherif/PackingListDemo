using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Exceptions
{
    public class InvalidTravelDaysException: PackingListException
    {
        public InvalidTravelDaysException(int value): base($"Invalid travel days value: {value}. Travel days must be between 1 and 100.")
        {
            
        }
    }
}
