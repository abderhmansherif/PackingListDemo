using PackingList.Domain.ValueObjects;
using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Exceptions
{
    public class MissingLocalizationWeatherException: PackingListException
    {
        public MissingLocalizationWeatherException(PackingListLocalization localization)
                :base($"Couldn't fetch weather data for localization '{localization.Country}/{localization.City}'")
        { }
    }
}
