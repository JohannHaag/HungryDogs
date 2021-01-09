using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryDogs.AspMvc.Models
{
    public class OpeningHour
    {
        public int Id { get; set; }
        public int Weekday { get; set; }
        public TimeSpan OpenFrom { get; set; }
        public TimeSpan OpenTo { get; set; }
        public string Notes { get; set; }

        public int RestaurantId { get; set; }
    }
}
