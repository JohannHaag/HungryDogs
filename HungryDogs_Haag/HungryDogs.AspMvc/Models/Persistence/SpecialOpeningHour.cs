using HungryDogs.Contracts.Modules.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryDogs.AspMvc.Models
{
    public class SpecialOpeningHour
    {
        public int Id { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Notes { get; set; }
        public SpecialOpenState State { get; set; }
        public int RestaurantId { get; set; }
    }
}
