using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Models
{
    public class LocalizationReadModel
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public static LocalizationReadModel Create (string value)
        {
            var parts = value.Split(',', 2);
            return new LocalizationReadModel()
            {
                Country = parts.First(),
                City = parts.Last()
            };
        }
        public override string ToString()
            => $"{Country},{City}";
    }
}
