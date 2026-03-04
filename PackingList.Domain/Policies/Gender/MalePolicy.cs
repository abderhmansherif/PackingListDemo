using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Policies.Gender
{
    public class MalePolicy : IPackingListPolicy
    {
        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
        {
            return new List<PackingListItem>
            {
                new("Gamed iPad", 1), 
                new("Action Figures", 5),
                new("Sports Equipment", 2) 
            };
        }

        public bool IsApplicable(PolicyData policyData)
        {
            return policyData.Gender == Consts.Gender.male;
        }
    }
}
