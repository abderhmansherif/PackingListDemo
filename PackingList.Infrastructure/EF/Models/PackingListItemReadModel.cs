using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PackingList.Infrastructure.EF.Models
{
    public class PackingListItemReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsPacked { get; set; }

        [ForeignKey("PackingListReadModel")]
        public Guid PackingListId { get; set; }
        public PackingListReadModel? PackingListReadModel { get; set; }
    }
}
