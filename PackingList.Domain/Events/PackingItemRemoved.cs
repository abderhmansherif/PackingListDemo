using PackingList.Domain.ValueObjects;
using PackingList.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Events
{
    public record PackingItemRemoved(PackingList.Domain.Entities.PackingList PackingList, PackingListItem PackingListItem) : IDomainEvent;
   
}
