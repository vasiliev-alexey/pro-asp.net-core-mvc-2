using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingViewComponents.Components
{
    using UsingViewComponents.Models;

    public class PocoViewComponent
    {
        private readonly ICityRepository repo;

        public PocoViewComponent(ICityRepository repo)
        {
            this.repo = repo;
        }


        public string Invoke()
        {
            return $"{repo.Cities.Count()} cities,"
                   + $"{repo.Cities.Sum(c => c.Population)} people";
        }

    }
}
