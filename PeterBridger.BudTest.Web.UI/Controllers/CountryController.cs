using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MediatR;
using PeterBridger.BudTest.Web.Features.Country;
using PeterBridger.BudTest.Web.Services;

namespace PeterBridger.BudTest.Web.UI.Controllers
{
    public class CountryController : Controller
    {
        private readonly IMediator _mediator;

        public CountryController() //  (IMediator mediator) 
        {
            // TODO Setup IoC Container, to provide dependancy injection 
        }

        public ActionResult Index( CountryQuery query )
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Result", query);
            }

            return View(query);
        }

        public async Task<ActionResult> Result(CountryQuery query)
        {
            // var result = await _mediator.Send<CountryViewModel>(query);

            // TODO Use Mediator and depedenacy injection
            var handler = new CountryHandler(new WorldBankDataService(new DeserializerService()));
            var result = await handler.Handle(query);

            return View(result);
        }
    }
}