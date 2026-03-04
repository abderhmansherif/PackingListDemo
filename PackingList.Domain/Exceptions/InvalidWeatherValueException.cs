using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Exceptions
{
    public class InvalidWeatherValueException : PackingListException
    {
        public InvalidWeatherValueException(double value) : base($"Invalid Temperature  value: {value}. Temperature  value must be between -100 and 100.")
        {
            
        }
    }
}
