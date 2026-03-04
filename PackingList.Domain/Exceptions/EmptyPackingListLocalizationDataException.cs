using PackingList.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Domain.Exceptions
{
    public class EmptyPackingListLocalizationDataException: PackingListException
    {
        public EmptyPackingListLocalizationDataException(): base ("Packing List Localization Data (City, Street) cannot be empty")
        {
            
        }
    }
}
