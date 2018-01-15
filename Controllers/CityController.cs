using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using UsingViewComponents.Models;
using System.Collections.Generic;

namespace UsingViewComponents.Controllers
{
    [ViewComponent(Name = "ComboComponent")]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository) => _cityRepository = cityRepository;

        public ActionResult Create() => View();

        [HttpPost]
        public RedirectToActionResult Create(City city)
        {
            _cityRepository.AddCity(city);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IViewComponentResult Invoke()
        {
            return new ViewViewComponentResult
            {
                ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData, _cityRepository.Cities)
            };
        }
    }
}