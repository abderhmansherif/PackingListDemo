using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.DTO
{
    public class PackingListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public LocalizationDTO? Localization { get; set; } 
        public List<PackingListItemDTO>? Items { get; set; }
    }
}
