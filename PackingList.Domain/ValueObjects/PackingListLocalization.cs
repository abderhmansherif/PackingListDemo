using PackingList.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.ValueObjects
{
    public record PackingListLocalization
    {
        public string Country { get; }
        public string City { get; }

        public PackingListLocalization(string country, string city)
        {
            if(string.IsNullOrEmpty(country) || string.IsNullOrEmpty(city))
            {
                throw new EmptyPackingListLocalizationDataException();
            }

            this.Country = city;
            this.City = country;
        }



        public static implicit operator string (PackingListLocalization localization)
                => $"{localization.Country},{localization.City}";
        
        public static implicit operator PackingListLocalization(string localization)
        {
            string[] localizationString = localization.Split(',', 2);

            return new PackingListLocalization(localizationString.First(), localizationString.Last());
        }

    }
}
