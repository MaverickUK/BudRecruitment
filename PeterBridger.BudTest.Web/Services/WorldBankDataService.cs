using Flurl.Http;
using PeterBridger.BudTest.Web.Models.WorldBank;
using System;
using System.Threading.Tasks;


namespace PeterBridger.BudTest.Web.Services
{
    public class WorldBankDataService : IWorldBankDataService
    {
        private const string BaseUrl = "http://api.worldbank.org";

        private readonly DeserializerService _deserializerService;

        public WorldBankDataService(DeserializerService deserializerService)
        {
            _deserializerService = deserializerService;
        }

        public async Task<Country> LoadCountry(string isoCode)
        {
            if (string.IsNullOrEmpty(isoCode) || isoCode.Length < 2 || isoCode.Length > 3)
            {
                throw new ArgumentException("A country iso code number be between 2 and 3 characters", nameof(isoCode));
            }

            var xml = await CallEndpoint($"/countries/{isoCode}");

            return _deserializerService.Deserialize<Countries>(xml).Country;
        }

        private static async Task<string> CallEndpoint(string endpoint)
        {
            return await $"{BaseUrl}{endpoint}".GetStringAsync();
        }
    }
}
