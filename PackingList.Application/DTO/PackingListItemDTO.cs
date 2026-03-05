using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.DTO
{
    public class PackingListItemDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsPacked { get; set; }
    }
}
