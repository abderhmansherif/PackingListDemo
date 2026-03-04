using System;
using System.Collections.Generic;
using System.Text;
using PackingList.Domain.Entities;
using PackingList.Domain.ValueObjects;

namespace PackingList.Domain.Repositories
{
    public interface IPackingListRepository
    {
        Task<Entities.PackingList> GetAsync(PackingListId packingListId);
        Task InsertAsync(Entities.PackingList packingList);
        Task UpdateAsync(Entities.PackingList packingList);
        Task DeleteAsync(Entities.PackingList packingList);
    }
}
