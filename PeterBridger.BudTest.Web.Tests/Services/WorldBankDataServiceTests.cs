using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeterBridger.BudTest.Web.Tests.Services
{
    [TestClass]
    public class WorldBankDataServiceTests
    {
        [TestMethod,TestCategory(Category.Integration)]
        public async Task LoadCountry_PassedBr_LoadsBrazil()
        {
            // Arrange
            var deserializerService = new Web.Services.DeserializerService();
            var worldBankDataService = new Web.Services.WorldBankDataService(deserializerService);

            // Act
            var country = await worldBankDataService.LoadCountry("br");
            
            // Assert
            Assert.AreEqual("Brazil", country.Name);
        }

        [TestMethod, TestCategory(Category.Integration)]
        public async Task LoadCountry_PassedUs_LoadsNorthAmerica()
        {
            // Arrange
            var deserializerService = new Web.Services.DeserializerService();
            var worldBankDataService = new Web.Services.WorldBankDataService(deserializerService);

            // Act
            var country = await worldBankDataService.LoadCountry("us");

            // Assert
            Assert.AreEqual("United States", country.Name);
        }
    }
}
