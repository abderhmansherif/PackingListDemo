using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Policies.Universal
{
    public class BasicPolicy : IPackingListPolicy
    {
        private const int MaximumQuantityOfClothes = 7;

        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
        {
            return new List<PackingListItem>
            {
                new("Pants", Math.Min(policyData.TravelDays.Value, MaximumQuantityOfClothes)),
                new("Socks", Math.Min(policyData.TravelDays.Value, MaximumQuantityOfClothes)),
                new("T-Shirt", Math.Min(policyData.TravelDays.Value, MaximumQuantityOfClothes)),
                new("Trousers", Math.Min(1, policyData.TravelDays.Value/7)),
                new("Shampoo", 1),
                new("Toothbrush", 1),
                new("Toothpaste", 1),
                new("Towel", 1),
                new("Bag pack", 1),
                new("Passport", 1),
                new("Phone Charger", 1)
            };
        }

        public bool IsApplicable(PolicyData _)
            => true;
    }
}
