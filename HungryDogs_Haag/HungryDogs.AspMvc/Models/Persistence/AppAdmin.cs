using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryDogs.AspMvc.Models.Persistence
{
    public class AppAdmin 
    {
        public IEnumerable<Restaurant> Restaurant { get; set; }
        public IEnumerable<OpeningHour> OpeningHour { get; set; }

        public Restaurant Restaurants { get; set; }
        public OpeningHour OpeningHours { get; set; }
    }
}
