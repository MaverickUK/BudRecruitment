using System;
using System.Threading.Tasks;
using MediatR;
using PeterBridger.BudTest.Web.Services;

namespace PeterBridger.BudTest.Web.Features.Country
{
    public class CountryHandler : IAsyncRequestHandler<CountryQuery, CountryViewModel>
    {
        private readonly IWorldBankDataService _worldBankDataService;

        public CountryHandler( IWorldBankDataService worldBankDataService )
        {
            _worldBankDataService = worldBankDataService ?? throw new ArgumentNullException(nameof(worldBankDataService));
        }

        public async Task<CountryViewModel> Handle(CountryQuery message)
        {
            var country = await _worldBankDataService.LoadCountry(message.Iso2Code);

            // TODO Use AutoMapper to map from domain to viewmodel
            var countryViewModel = new CountryViewModel
            {
                AdminRegion = country.AdminRegion,
                CapitalCity = country.CapitalCity,
                Iso2Code = country.Iso2Code,
                Latitude = country.Latitude,
                Longitude = country.Longitude,
                Name = country.Name
            };

            return countryViewModel;
        }
    }
}
