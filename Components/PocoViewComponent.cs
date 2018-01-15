using System.Linq;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class PocoViewComponent
    {
        private ICityRepository _cityRepository;

        public PocoViewComponent(ICityRepository cityRepository) => _cityRepository = cityRepository;

        public string Invoke() => $"{_cityRepository.Cities.Count()} cities, {_cityRepository.Cities.Sum(p => p.Population)} people";

    }
}