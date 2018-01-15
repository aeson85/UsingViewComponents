using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository _cityRepository;

        public CitySummary(ICityRepository cityRepository) => _cityRepository = cityRepository;

        public IViewComponentResult Invoke(bool showList)
        {  
            if (showList)
            {
                return View("CityList", _cityRepository.Cities);
            }
            else
            {
                 return View(new CityViewModel
                {
                    Cities = _cityRepository.Cities.Count(),
                    Population = _cityRepository.Cities.Sum(p => p.Population)
                });
				
				
            }
        }
    }
}