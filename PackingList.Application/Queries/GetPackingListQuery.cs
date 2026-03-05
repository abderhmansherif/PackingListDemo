using PackingList.Application.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Queries
{
    public record GetPackingListQuery(Guid PackingListId) : IQuery;
}
