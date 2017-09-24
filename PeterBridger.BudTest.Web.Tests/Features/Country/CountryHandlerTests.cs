using System;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeterBridger.BudTest.Web.Features.Country;
using PeterBridger.BudTest.Web.Services;

namespace PeterBridger.BudTest.Web.Tests.Features.Country
{
    [TestClass]
    public class CountryHandlerTests
    {

        #region Constructor

        [TestMethod, TestCategory(Category.Unit)]
        public void Constructor_NullWorldBankDataService_ThrowsArgumentNullException()
        {
            // Arrange
            const string expectedExceptionParamName = "worldBankDataService";

            // Act & assert
            try
            {
                var handler = new CountryHandler(null);
                Assert.Fail("Passing a null worldBankDataService into CountryHandler constructor should throw ArgumentNullException");
            }
            catch (ArgumentNullException exp)
            {
                Assert.AreEqual(expectedExceptionParamName, exp.ParamName);
            }
        }

        #endregion

        #region Handle

        [TestMethod, TestCategory(Category.Unit)]
        public async Task Handle_ValidInvoke_CallsLoadCountry()
        {
            // Arrange
            var query = new CountryQuery
            {
                Iso2Code = "br"
            };

            var worldBankDataServiceMock = new Mock<IWorldBankDataService>();
            worldBankDataServiceMock.Setup(x => x.LoadCountry(query.Iso2Code)).ReturnsAsync(new Models.WorldBank.Country());

            var handler = new CountryHandler(worldBankDataServiceMock.Object);

            // Act
            await handler.Handle(query);

            // Asset
            worldBankDataServiceMock.Verify(x => x.LoadCountry(query.Iso2Code), Times.Exactly(1));
        }

        [TestMethod, TestCategory(Category.Unit)]
        public async Task Handle_CountryLoaded_MapsToViewModel()
        {
            // Arrange
            var query = new CountryQuery
            {
                Iso2Code = "br"
            };

            var country = new Models.WorldBank.Country
            {
                Iso2Code = "br",
                CapitalCity = "capital city",
                Name = "My city",
                Longitude = 34.4545d,
                Latitude = -3.5658787d,
                AdminRegion = "Admin region"
            };

            var expectedCountryViewModel = new CountryViewModel
            {
                Iso2Code = country.Iso2Code,
                CapitalCity = country.CapitalCity,
                AdminRegion = country.AdminRegion,
                Longitude = country.Longitude,
                Latitude = country.Latitude,
                Name = country.Name
            };


            var worldBankDataServiceMock = new Mock<IWorldBankDataService>();
            worldBankDataServiceMock.Setup(x => x.LoadCountry(query.Iso2Code)).ReturnsAsync(country);

            var handler = new CountryHandler(worldBankDataServiceMock.Object);

            // Act
            var actualCountryViewModel = await handler.Handle(query);

            // Assert
            Assert.IsTrue( expectedCountryViewModel.IsDeepEqual(actualCountryViewModel) );
        }

        #endregion
    }
}
