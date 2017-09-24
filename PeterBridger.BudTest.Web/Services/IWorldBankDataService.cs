using System.Threading.Tasks;
using PeterBridger.BudTest.Web.Models.WorldBank;

namespace PeterBridger.BudTest.Web.Services
{
    public interface IWorldBankDataService
    {
        Task<Country> LoadCountry(string isoCode);
    }
}