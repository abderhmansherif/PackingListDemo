using PackingList.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.ValueObjects
{
    public record TravelDays
    {
        public int Value { get; }

        public TravelDays(int value) 
        {
            if (value <= 0 || value > 100)
            {
                throw new InvalidTravelDaysException(value);
            }

            Value = value;
        }

        public static implicit operator int(TravelDays travelDays)
            => travelDays.Value;

        public static implicit operator TravelDays(int value)
            => new TravelDays(value);
    }
}
