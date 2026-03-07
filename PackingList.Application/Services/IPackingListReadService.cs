using PackingList.Application.DTO;
using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Services
{
    public interface IPackingListReadService
    {
        Task<bool> ExistsPackingListNameAsync(string PackingListName);
    }
}
