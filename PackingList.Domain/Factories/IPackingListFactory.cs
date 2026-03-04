using PackingList.Domain.Consts;
using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Factories
{
    public interface IPackingListFactory
    {
        PackingList.Domain.Entities.PackingList Create(PackingListId id, PackingListName name, 
                                                       PackingListLocalization localization);

        PackingList.Domain.Entities.PackingList CreateWithDefaultItems(PackingListId id, PackingListName name,
             PackingListLocalization localization, Temperature Temperature, Gender gender, TravelDays travelDays);

    }
}
