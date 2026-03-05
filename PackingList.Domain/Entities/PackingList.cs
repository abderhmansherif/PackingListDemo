using PackingList.Domain.Events;
using PackingList.Domain.Exceptions;
using PackingList.Domain.ValueObjects;
using PackingList.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Entities
{
    public class PackingList: AggregateRoot
    {
        public PackingListId Id { get; private set; }

        private PackingListName _name;

        private PackingListLocalization _localization;

        private readonly LinkedList<PackingListItem> _items = new();

        internal PackingList(PackingListId id, PackingListName name, PackingListLocalization localization)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }

        public void AddItem(PackingListItem item)
        {
            if(_items.Any(x => x.Name == item.Name))
            {
                throw new AlreadyExistPackingItemException(item.Name);
            }

            _items.AddLast(item);

            //Storing domain event
            AddDomainEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingListItem> items)
        {
            foreach (var item in items)
                AddItem(item);
        }

        public void PackItem(string ItemName)
        {
            var item = GetItem(ItemName);
            
            if(item.IsPacked)
            {
                throw new AlreadyPackedPackingItemException(ItemName);
            }

            var packedItem = item with { IsPacked = true };

            _items.Find(item)!.Value = packedItem;

            //Storing domain event
            AddDomainEvent(new PackingItemPacked(this, packedItem));
        }

        public void RemoveItem(string ItemName)
        {
            var item = GetItem(ItemName);

            _items.Remove(item);

            //Storing domain event
            AddDomainEvent(new PackingItemRemoved(this, item));
        }

        private PackingListItem GetItem(string ItemName)
        {
            var item = _items.SingleOrDefault(x => x.Name == ItemName);

            if(item is null)
            {
                throw new NotFoundPackingListItemException(ItemName);
            }

            return item;
        }
    }
}
