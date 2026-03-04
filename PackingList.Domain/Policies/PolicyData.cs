using PackingList.Domain.Consts;
using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Policies
{
    public record PolicyData(TravelDays TravelDays, ValueObjects.Temperature Temperature, Consts.Gender Gender, PackingListLocalization PackingListLocalization);
    
}
