using PackingList.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.ValueObjects
{
    public record Temperature
    {
        public double Value { get; }

        public Temperature(double value) 
        {
            if(value >= 100 || value <= -100)
            {
                throw new InvalidWeatherValueException(value);
            }

            Value = value;
        }

        public static implicit operator double(Temperature temperature)
            => temperature.Value;

        public static implicit operator Temperature(double value)
            => new Temperature(value);
    }
}
