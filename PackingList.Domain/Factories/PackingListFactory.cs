using PackingList.Domain.Consts;
using PackingList.Domain.Policies;
using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Factories
{
    public class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingListPolicy> _packingListPolicies;

        public PackingListFactory(IEnumerable<IPackingListPolicy> packingListPolicies)
        {
            _packingListPolicies = packingListPolicies;
        }

        public Entities.PackingList Create(PackingListId id, PackingListName name, PackingListLocalization localization)
        {
            return new Entities.PackingList(id, name, localization);
        }

        public Entities.PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, PackingListLocalization localization, Temperature Temperature, Gender gender, TravelDays travelDays)
        {
            var policyData = new PolicyData(travelDays, Temperature, gender, localization);

            IEnumerable<PackingListItem> Items = _packingListPolicies.Where(p => p.IsApplicable(policyData))
                                                          .SelectMany(p => p.GenerateItems(policyData))
                                                          .ToList();

            var PackingList = new Entities.PackingList(id, name, localization);
            PackingList.AddItems(Items);

            return PackingList;
        }
    }
}
