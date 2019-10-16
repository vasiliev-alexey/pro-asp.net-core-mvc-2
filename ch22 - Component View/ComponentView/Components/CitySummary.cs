using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingViewComponents.Components
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewComponents;

    using UsingViewComponents.Models;

    public class CitySummary : ViewComponent
    {
        private readonly ICityRepository cityRepository;

        public CitySummary(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public IViewComponentResult Invoke( bool showList)
        {
            /*
            return $"{cityRepository.Cities.Count()} Городов,"
                   + $"{cityRepository.Cities.Sum(c => c.Population)} Население";
        
    */
            /*  return View(new CityViewModel
                              {
                                  Cities = cityRepository.Cities.Count(),
                                  Population = cityRepository.Cities.Sum(c => c.Population)

          });*/
            // return new HtmlContentViewComponentResult(
            // new HtmlString("This is а <hЗ><i>string</iX/hЗ>"));
           
            /*
            var target = RouteData.Values["id"] as string;
            var cities = cityRepository.Cities.Where(
                city => target == null || string.Compare(city.Country, target, true) == 0);

            return View(new CityViewModel { Cities = cities.Count(), Population = cities.Sum(c => c.Population) });
            */
            if (showList)
            {
                return View("CityList", cityRepository.Cities);
            }
            else
            {
                var cities = cityRepository.Cities;

                return View(new CityViewModel { Cities = cities.Count(), Population = cities.Sum(c => c.Population) });
            }

        }
    }
}