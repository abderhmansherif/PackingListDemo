using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PackingList.Domain.Policies.Temperature
{
    public class LowTemperaturePolicy : IPackingListPolicy
    {
        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
        {
            return new List<PackingListItem>
            {
                new("Warm Coat",1),
                new("Thermal Underwear", 2),
                new("Gloves", 1),
                new("Scarf", 1),
                new("Warm Hat",  1)
            };
        }

        public bool IsApplicable(PolicyData policyData)
        {
            return policyData.Temperature < 10;
        }
    }
}
