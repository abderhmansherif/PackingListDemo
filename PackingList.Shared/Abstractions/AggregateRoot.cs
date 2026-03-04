using PackingList.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Shared.Abstractions
{
    public class AggregateRoot
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> GetDomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

    }
}
