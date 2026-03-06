using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Shared.Options
{
    public static class Extenstions
    {
        public static TOption GetOption<TOption>(this IConfiguration configuration, string SectionName) where TOption : new()
        {
            var option = new TOption();

            configuration.GetSection(SectionName).Bind(option);

            return option;
        }
    }
}
