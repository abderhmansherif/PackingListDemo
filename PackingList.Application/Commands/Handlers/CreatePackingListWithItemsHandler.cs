using PackingList.Application.Abstractions.Commands;
using PackingList.Application.Exceptions;
using PackingList.Application.Services;
using PackingList.Domain.Factories;
using PackingList.Domain.Repositories;
using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListFactory _factory;
        private readonly IPackingListRepository _repository;
        private readonly IPackingListReadService _packingListReadService;
        private readonly IWeatherService _weatherService;
        public CreatePackingListWithItemsHandler(IPackingListFactory factory,
                                                 IPackingListRepository repository,
                                                 IPackingListReadService packingListReadService,
                                                 IWeatherService weatherService)
        {
            _factory = factory;
            _repository = repository;
            _packingListReadService = packingListReadService;
            _weatherService = weatherService;
        }

        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            var (id, name, days, gender, localizationWriteModel) = command;

            if(await _packingListReadService.ExistsPackingListNameAsync(name))
            {
                throw new AlreadyExistsPackingListNameException(name);
            }

            var localization = new PackingListLocalization(localizationWriteModel.Country, localizationWriteModel.City);

            var weather = await _weatherService.GetWeatherAsync(localization);

            if(weather is null)
            {
                throw new MissingLocalizationWeatherException(localization);
            }

            var packinglist = _factory.CreateWithDefaultItems(id, name, localization, weather.Temperature, gender, days);

            await _repository.InsertAsync(packinglist);
        }
    }
}
