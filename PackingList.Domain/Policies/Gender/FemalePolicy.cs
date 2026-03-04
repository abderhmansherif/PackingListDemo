using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Policies.Gender
{
    public class FemalePolicy : IPackingListPolicy
    {
        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
        {
            return new List<PackingListItem>
            {
                new("Dresses", 2),
                new("Skirts", 2),
                new("Blouses", 3),
                new("Heels", 1),
            };
        }

        public bool IsApplicable(PolicyData policyData)
        {
            return policyData.Gender == Consts.Gender.female;
        }
    }
}
