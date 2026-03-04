using PackingList.Domain.Consts;

namespace PackingList.Application.Commands
{
    public record CreatePackingListWithItems(Guid id, string name, int days, Gender Gender, 
           LocalizationWriteModel LocalizationWriteModel) : Abstractions.Commands.ICommand;

    public record LocalizationWriteModel(string Country, string City);
}
