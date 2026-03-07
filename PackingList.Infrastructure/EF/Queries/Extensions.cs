using PackingList.Application.DTO;
using PackingList.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static PackingListDTO AsDTO(this PackingListReadModel packingList)
        {
            return new PackingListDTO()
            {
                Id = packingList.Id,
                Name = packingList.Name,
                Localization = new() 
                {
                    Country = packingList.Localization!.Country,
                    City = packingList.Localization.City,
                },
                Items = packingList.Items?.Select(i => new PackingListItemDTO 
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    IsPacked = i.IsPacked,
                }).ToList()
            };
        }
    }
}
