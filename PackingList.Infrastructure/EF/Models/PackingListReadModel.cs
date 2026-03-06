using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Models
{
    public class PackingListReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public LocalizationReadModel? Localization { get; set; } 
        public ICollection<PackingListItemReadModel>? Items { get; set; }
    }
}
