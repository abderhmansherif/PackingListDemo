using PackingList.Application.DTO.External;
using PackingList.Application.Services;
using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Services
{
    internal class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDTO> GetWeatherAsync(PackingListLocalization packingListLocalization)
            => Task.FromResult(new WeatherDTO(new Random().Next(5, 60)));
    }
}
