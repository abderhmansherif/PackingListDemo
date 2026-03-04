using PackingList.Application.DTO.External;
using PackingList.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDTO> GetWeatherAsync(PackingListLocalization packingListLocalization);
    }
}
