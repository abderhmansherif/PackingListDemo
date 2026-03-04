using PackingList.Domain.ValueObjects;
using PackingList.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Events
{
    public record PackingItemAdded(PackingList.Domain.Entities.PackingList PackingList, 
                                                                    PackingListItem item): IDomainEvent;

}
