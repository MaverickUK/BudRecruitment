using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PeterBridger.BudTest.Web.Features.Country
{
    public class CountryQuery : IRequest<CountryViewModel>
    {
        private const string ErrorMessage = "Please enter a country iso code, between 2 and 3 letters in length";

        [Required(ErrorMessage = ErrorMessage),RegularExpression("^[a-zA-Z]{2,3}$", ErrorMessage = ErrorMessage)]
        public string Iso2Code { get; set; }
    }
}
