using HungryDogs.Contracts.Modules.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryDogs.AspMvc.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string UniqueName { get; set; }
        public string Email { get; set; }
        public RestaurantState State { get; set; }
    }
}
