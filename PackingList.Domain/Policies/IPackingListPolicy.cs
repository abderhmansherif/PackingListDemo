using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Policies
{
    public interface IPackingListPolicy
    {
        bool IsApplicable(PolicyData policyData);

        IEnumerable<PackingListItem> GenerateItems(PolicyData policyData);

    }
}
