using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Policies.Temperature
{
    public class HighTemperaturePolicy : IPackingListPolicy
    {
        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
        {
            return new List<PackingListItem>
            {
                new("Sunscreen", 1), 
                new("Hat", 1) ,
                new("Sunglasses", 1)  
            };
        }

        public bool IsApplicable(PolicyData policyData)
        {
            return policyData.Temperature > 10;
        }
    }
}
